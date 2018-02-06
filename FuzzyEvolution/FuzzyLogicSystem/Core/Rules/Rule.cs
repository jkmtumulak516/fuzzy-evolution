using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using System.Text;

namespace FuzzyLogicSystems.Core.Rules
{
    public abstract class Rule
    {
        private readonly List<IRulePart> _rule_parts;
        private readonly List<IRulePart> _post_fix_parts;
        private readonly ResultFuzzyMember _result;
        private readonly string _print_output;

        internal Rule(List<IRulePart> ruleParts, ResultFuzzyMember result)
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

        internal IList<IRulePart> RuleParts { get => _rule_parts; }
        internal IList<IRulePart> PostFixParts { get => _post_fix_parts; }
        public ResultFuzzyMember Result { get => _result; }

        public bool Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues)
        {
            var operandStack = new Stack<bool>();

            foreach (IRulePart part in RuleParts)
                part.Evaluate(fuzzifiedValues, operandStack);

            bool outcome = operandStack.Pop();

            return outcome;
        }

        internal void ToPostFix()
        {
            var operandStack = new Stack<RuleOperator>();

            foreach (IRulePart part in RuleParts)
                part.ToPostFix(PostFixParts, operandStack);

            while (operandStack.Count > 0)
                PostFixParts.Add(operandStack.Pop());
        }

        public override string ToString()
        {
            return _print_output;
        }
    }
}
