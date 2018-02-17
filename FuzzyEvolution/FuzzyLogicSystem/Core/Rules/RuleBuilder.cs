using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Rules.Operators;
using FuzzyLogicSystems.Core.Rules.Exception;

namespace FuzzyLogicSystems.Core.Rules
{
    public class RuleBuilder
    {
        private const int None = 0;
        private const int Operand = 1;
        private const int Operator = 2;

        private IList<IRulePart> _rule_parts;

        private int LastAdded;

        public RuleBuilder()
        {
            _rule_parts = new List<IRulePart>();
            LastAdded = None;
        }

        private IList<IRulePart> RuleParts { get => _rule_parts; }

        public RuleBuilder Var(IFuzzyMember fuzzyMember)
        {
            if (LastAdded == Operand) throw new RuleSyntaxException("Cannot add Operand. Operands must be separated by an Operator.");

            RuleParts.Add(new RuleOperand(fuzzyMember));

            LastAdded = Operand;
            return this;
        }

        public RuleBuilder And()
        {
            if (LastAdded == Operator) throw new RuleSyntaxException("Cannot add Operator. Operators must be separated by an Operand.");
            if (LastAdded == None) throw new RuleSyntaxException("Cannot add Operator. An Operand must be added first.");

            RuleParts.Add(AndOperator.Get);

            LastAdded = Operator;
            return this;
        }

        public RuleBuilder Or()
        {
            if (LastAdded == Operator) throw new RuleSyntaxException("Cannot add Operator. Operators must be separated by an Operand.");
            if (LastAdded == None) throw new RuleSyntaxException("Cannot add Operator. An Operand must be added first.");

            RuleParts.Add(OrOperator.Get);

            LastAdded = Operator;
            return this;
        }

        public ParentRule Build(IResultFuzzyMember result)
        {
            if (LastAdded == Operator) throw new RuleSyntaxException("Cannot build Rule. Rules cannot end with operators.");
            if (LastAdded == None) throw new RuleSyntaxException("Cannot build Rule. Rules is empty.");

            var rule = new ParentRule(RuleParts, result);
            return rule;
        }

        public void Reset()
        {
            LastAdded = None;

            _rule_parts = new List<IRulePart>();
        }
    }
}
