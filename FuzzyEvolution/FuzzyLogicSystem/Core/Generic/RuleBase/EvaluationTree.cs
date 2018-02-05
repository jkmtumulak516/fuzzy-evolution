using System.Collections.Generic;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.RuleBase
{
    public partial class EvaluationTreeRuleBase
    {
        private class EvaluationTree
        {
            private readonly EvaluationNode _root;
            private readonly IDictionary<int, int> _category_order;
            private readonly int _max_depth;

            public EvaluationTree(IList<FuzzySet<InputFuzzyMember>> inputFuzzySets, IEnumerable<ParentRule> rules)
            {
                _root = new BranchNode(this);
                // key: depth, value: category
                _category_order = new Dictionary<int, int>();
                
                // determine the order of the categories
                int i = 0;
                foreach (var fuzzySet in inputFuzzySets)
                    _category_order.Add(i++, fuzzySet.Category);

                // determine max depth of the tree
                _max_depth = _category_order.Count + 1;

                foreach (var rule in rules)
                    AddRule(rule);
            }

            public EvaluationNode Root { get => _root; }
            public IDictionary<int, int>  CategoryOrder { get => _category_order; }
            public int MaxDepth { get => _max_depth; }

            private void AddRule(ParentRule parentRule)
            {
                IList<SubRule> subRules = parentRule.SubRules();

                foreach (var subRule in subRules)
                    Root.AddRule(subRule);
            }

            public IList<ResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues)
            {
                return Root.Evaluate(fuzzifiedValues);
            }
        }

        private abstract class EvaluationNode
        {
            private readonly EvaluationTree _tree;
            private readonly EvaluationNode _parent;
            private readonly int _depth;
            private readonly int _category;

            public EvaluationNode(EvaluationTree tree)
            {
                _tree = tree;
                _parent = null;
                _depth = 1;
                _category = Tree.CategoryOrder[_depth];
            }

            public EvaluationNode(EvaluationNode parent)
            {
                _tree = parent.Tree;
                _parent = parent;
                _depth = parent.Depth + 1;
                _category = Tree.CategoryOrder[_depth];
            }

            public EvaluationTree Tree { get => _tree; }
            public EvaluationNode Parent { get => _parent; }
            public int Depth { get => _depth; }
            public int Category { get => _category; }
            public abstract bool ChildrenAreLeaves { get; }

            public abstract void AddRule(SubRule rule);
            // nullable
            public abstract IList<ResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues);
        }

        private class BranchNode : EvaluationNode
        {
            private readonly IDictionary<string, EvaluationNode> _children;
            private readonly EvaluationNode _nil_child;
            private readonly bool _children_are_leaves;
            
            public BranchNode(EvaluationTree tree) : base(tree)
            {
                _children = new Dictionary<string, EvaluationNode>(3);
                _children_are_leaves = Depth == Tree.MaxDepth - 1;

                if (!ChildrenAreLeaves)
                    _nil_child = new BranchNode(tree);
                else
                    _nil_child = new LeafNode(tree);
            }

            public BranchNode(EvaluationNode parent) : base(parent)
            {
                _children = new Dictionary<string, EvaluationNode>(3);
                _children_are_leaves = Depth == Tree.MaxDepth - 1;

                if (!ChildrenAreLeaves)
                    _nil_child = new BranchNode(parent);
                else
                    _nil_child = new LeafNode(parent);
            }

            public IDictionary<string, EvaluationNode> Children { get => _children; }
            public EvaluationNode NilChild { get => _nil_child; }
            public override bool ChildrenAreLeaves { get => _children_are_leaves; }

            public override IList<ResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues)
            {
                if (fuzzifiedValues.ContainsKey(Category))
                {
                    string name = fuzzifiedValues[Category].FuzzyMember.Name;
                    return Children[fuzzifiedValues[Category].FuzzyMember.Name].Evaluate(fuzzifiedValues);
                }
                    
                else
                    return NilChild.Evaluate(fuzzifiedValues);
            }

            public override void AddRule(SubRule rule)
            {
                var operand = rule[Category];

                if (operand != null) // if an operand in this node's category exists, add to respective child node
                {
                    if (!Children.ContainsKey(operand.FuzzyMember.Name)) // if corresponding child node does not exist
                    {
                        EvaluationNode childNode = null;

                        // add either a leaf or branch node as child
                        if (!ChildrenAreLeaves) 
                            childNode = new BranchNode(Parent);
                        else
                            childNode = new LeafNode(Parent);

                        Children.Add(operand.FuzzyMember.Name, childNode);
                    }

                    Children[operand.FuzzyMember.Name].AddRule(rule);
                }

                else // if an operand in this node's category DOES NOT exist, add to the nil node
                    NilChild.AddRule(rule);
            }
        }

        private class LeafNode : EvaluationNode
        {
            private readonly IList<Rule> _children;

            public LeafNode(EvaluationTree tree) : base(tree) { _children = new List<Rule>(1); }
            public LeafNode(EvaluationNode parent) : base(parent) { _children = new List<Rule>(1); }

            private IList<Rule> Children { get => _children; }
            public override bool ChildrenAreLeaves { get => false; }

            public override IList<ResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues)
            {
                if (Children.Count > 0)
                {
                    var results = new List<ResultFuzzyMember>(Children.Count);

                    foreach (var child in Children)
                    {
                        if (child.Evaluate(fuzzifiedValues))
                            results.Add(child.Result);
                    }

                    return results.Count > 0 ? results : null;
                }

                else return null;
            }

            public override void AddRule(SubRule rule)
            {
                Children.Add(rule);
            }
        }
    }
}
