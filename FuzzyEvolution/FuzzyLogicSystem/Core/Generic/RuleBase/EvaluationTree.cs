using System.Collections.Generic;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.RuleBase
{
    public partial class EvaluationTreeRuleBase
    {
        private class EvaluationTree
        {
            private readonly IDictionary<string, EvaluationNode> _roots;

            public EvaluationTree(IList<FuzzySet<InputFuzzyMember>> inputFuzzySets, IEnumerable<Rule> rules)
            {
                // key: depth, value: category
                var categoryOrder= new Dictionary<int, int>();
                _roots = new Dictionary<string, EvaluationNode>();

                int i = 0;

                foreach (var fuzzySet in inputFuzzySets)
                    categoryOrder.Add(i++, fuzzySet.Category);

                foreach (var rule in rules)
                {
                    if (rule is ParentRule)
                        AddRule(rule as ParentRule);
                    else
                        AddRule(rule);
                }
            }

            private IDictionary<string, EvaluationNode> Roots { get => _roots; }

            private void AddRule(ParentRule parentRule)
            {
                IList<SubRule> subRules = parentRule.SubRules();

                foreach (var subRule in subRules)
                    AddRule(subRule);
            }

            private void AddRule(Rule subRule)
            {

            }
        }

        private class EvaluationNode
        {
            private readonly IFuzzyMember _fuzzy_member;
            private readonly EvaluationNode _parent;
            private readonly IDictionary<string, EvaluationNode> _children;
            private readonly int _depth;

            public EvaluationNode(IFuzzyMember fuzzyMember, EvaluationNode parent = null)
            {
                _fuzzy_member = fuzzyMember;
                _children = new Dictionary<string, EvaluationNode>(3);
                _parent = parent;
                _depth = (parent?.Depth ?? 0) + 1;
            }

            public IFuzzyMember FuzzyMember { get => _fuzzy_member; }
            public EvaluationNode Parent { get => _parent; }
            public IDictionary<string, EvaluationNode> Children { get => _children; }
            public int Depth { get => _depth; }
        }
    }
}
