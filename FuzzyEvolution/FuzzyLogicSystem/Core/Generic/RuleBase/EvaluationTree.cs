using System.Collections.Generic;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using System.Text;

namespace FuzzyLogicSystems.Core.Generic.RuleBase
{
    public partial class EvaluationTreeRuleBase
    {
        private class EvaluationTree
        {
            private readonly EvaluationNode _root;
            private readonly IDictionary<int, int> _category_order;
            private readonly int _max_depth;

            public EvaluationTree(IList<FuzzySet<IInputFuzzyMember>> inputFuzzySets, IEnumerable<ParentRule> rules)
            {
                //key: depth, value: category
                _category_order = new Dictionary<int, int>();

                // determine the order of the categories
                int i = 1;
                foreach (var fuzzySet in inputFuzzySets)
                    _category_order.Add(i++, fuzzySet.Category);

                // determine max depth of the tree
                _max_depth = _category_order.Count + 1;

                _root = new BranchNode(this);

                foreach (var rule in rules)
                    AddRule(rule);
            }

            public EvaluationNode Root { get => _root; }
            public IDictionary<int, int> CategoryOrder { get => _category_order; }
            public int MaxDepth { get => _max_depth; }

            private void AddRule(ParentRule parentRule)
            {
                IList<SubRule> subRules = parentRule.SubRules();

                foreach (var subRule in subRules)
                    Root.AddRule(subRule);
            }

            public IList<IResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<IInputFuzzyMember>> fuzzifiedValues)
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
                _category = Tree.CategoryOrder.ContainsKey(_depth) ? Tree.CategoryOrder[_depth] : 0;
            }

            public EvaluationTree Tree { get => _tree; }
            public EvaluationNode Parent { get => _parent; }
            public int Depth { get => _depth; }
            public int Category { get => _category; }
            public abstract bool ChildrenAreLeaves { get; }

            public abstract void AddRule(SubRule rule);
            // nullable
            public abstract IList<IResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<IInputFuzzyMember>> fuzzifiedValues);
        }

        private class BranchNode : EvaluationNode
        {
            private readonly IDictionary<string, EvaluationNode> _children;
            private EvaluationNode _nil_child;
            private readonly bool _children_are_leaves;

            public BranchNode(EvaluationTree tree) : base(tree)
            {
                _children = new Dictionary<string, EvaluationNode>(3);
                _children_are_leaves = Depth == Tree.MaxDepth - 1;
            }

            public BranchNode(EvaluationNode parent) : base(parent)
            {
                _children = new Dictionary<string, EvaluationNode>(3);
                _children_are_leaves = Depth == Tree.MaxDepth - 1;
            }

            public IDictionary<string, EvaluationNode> Children { get => _children; }
            public EvaluationNode NilChild { get => _nil_child; }
            public override bool ChildrenAreLeaves { get => _children_are_leaves; }

            public override IList<IResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<IInputFuzzyMember>> fuzzifiedValues)
            {
                if (fuzzifiedValues.ContainsKey(Category))
                {
                    string name = fuzzifiedValues[Category].FuzzyMember.Name;
                    return Children[name].Evaluate(fuzzifiedValues);
                }

                else
                    return NilChild?.Evaluate(fuzzifiedValues);
            }

            public override void AddRule(SubRule subRule)
            {
                //throw new System.Exception(subRule.Categories.Count.ToString());
                
                var ruleOperand = subRule[Category];

                if (ruleOperand == null) // no ruleOperand within the given category is within this subRule
                {
                    if (NilChild == null)
                    {
                        if (!ChildrenAreLeaves)
                            _nil_child = new BranchNode(this);
                        else
                            _nil_child = new LeafNode(this);
                    }

                    NilChild.AddRule(subRule);
                }

                else // a ruleOperand DOES exist in this node's particular category
                {
                    string name = ruleOperand.FuzzyMember.Name;

                    if (!Children.ContainsKey(name))
                    {
                        if (!ChildrenAreLeaves)
                            Children.Add(name, new BranchNode(this));
                        else
                            Children.Add(name, new LeafNode(this));
                    }

                    string temp = Children.ToString();
                    Children[name].AddRule(subRule);
                }
            }
        }

        private class LeafNode : EvaluationNode
        {
            private readonly IList<Rule> _children;

            public LeafNode(EvaluationTree tree) : base(tree) { _children = new List<Rule>(1); }
            public LeafNode(EvaluationNode parent) : base(parent) { _children = new List<Rule>(1); }

            private IList<Rule> Children { get => _children; }
            public override bool ChildrenAreLeaves { get => false; }

            public override IList<IResultFuzzyMember> Evaluate(IDictionary<int, FuzzyValue<IInputFuzzyMember>> fuzzifiedValues)
            {
                if (Children.Count > 0)
                {
                    var results = new List<IResultFuzzyMember>(Children.Count);

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
