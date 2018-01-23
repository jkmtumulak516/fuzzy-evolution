using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Rules.Operators;

namespace FuzzyLogicSystems.Core.Rules
{
    public class RuleBuilder
    {
        private readonly List<IRulePart> _ruleParts;
        private readonly HashSet<int> _categories;

        public RuleBuilder()
        {
            _ruleParts = new List<IRulePart>();
            _categories = new HashSet<int>();
        }

        private List<IRulePart> RuleParts { get => _ruleParts; }
        private HashSet<int> Categories { get => _categories; }

        public RuleBuilder Var(int category, string name, bool negate = false)
        {
            if (negate)
                RuleParts.Add(NotOperator.Get);

            RuleParts.Add(new RuleOperand(category, name));

            return this;
        }

        public RuleBuilder And()
        {
            RuleParts.Add(AndOperator.Get);
            return this;
        }

        public RuleBuilder Or()
        {
            RuleParts.Add(OrOperator.Get);
            return this;
        }

        public Rule Build(ResultFuzzyMember result)
        {
            var rule = new Rule(RuleParts, Categories, result);
            return rule;
        }

        public void Reset()
        {
            RuleParts.Clear();
            Categories.Clear();
        }
    }
}
