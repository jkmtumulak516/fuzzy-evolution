using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using System.Text;
using System;

namespace FuzzyLogicSystems.Core.Rules
{
    public abstract class Rule
    {
        private readonly List<IRulePart> _rule_parts;
        private readonly List<IRulePart> _post_fix_parts;
        private readonly IResultFuzzyMember _result;
        private readonly string _print_output;

        internal Rule(List<IRulePart> ruleParts, IResultFuzzyMember result)
        {
            _rule_parts = ruleParts;
            _post_fix_parts = new List<IRulePart>(ruleParts.Count);

            _result = result;

            var sb = new StringBuilder();

            foreach (var rulePart in _rule_parts)
                sb.Append(rulePart.ToString()).Append(" ");

            _print_output = sb.ToString();

            ToPostFix();
        }

        internal List<IRulePart> RuleParts { get => _rule_parts; }
        internal List<IRulePart> PostFixParts { get => _post_fix_parts; }
        public IResultFuzzyMember Result { get => _result; }

        public bool Evaluate(IDictionary<int, FuzzyValue<IInputFuzzyMember>> fuzzifiedValues)
        {
            var operandStack = new Stack<bool>();

            foreach (IRulePart part in PostFixParts)
                part.Evaluate(fuzzifiedValues, operandStack);

            bool outcome = operandStack.Pop();

            return outcome;
        }

        internal void ToPostFix()
        {
            var operatorStack = new Stack<RuleOperator>();

            foreach (IRulePart part in RuleParts)
                part.ToPostFix(PostFixParts, operatorStack);

            while (operatorStack.Count > 0)
                PostFixParts.Add(operatorStack.Pop());
        }

        public override string ToString()
        {
            return _print_output;
        }
    }
}
