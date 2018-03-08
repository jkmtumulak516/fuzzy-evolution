using System.Linq;
using System.Collections.Generic;
using System.Text;
using FuzzyLogicSystems.Core.Values;
using EvolutionaryAlgorithms.Genetic;

namespace FuzzyLogicSystems.Core.Rules
{
    public abstract class Rule : IGene<Rule>
    {
        private readonly IList<IRulePart> _rule_parts;
        private readonly IList<IRulePart> _post_fix_parts;
        private IResultFuzzyMember _result;
        private string _print_output;

        internal Rule(IList<IRulePart> ruleParts, IResultFuzzyMember result)
        {
            _rule_parts = ruleParts;
            _post_fix_parts = new List<IRulePart>(ruleParts.Count);

            _result = result;

            var sb = new StringBuilder();

            foreach (var rulePart in _rule_parts)
                sb.Append(rulePart.ToString()).Append(" ");
            sb.Append(" => ").Append(_result.ToString());

            _print_output = sb.ToString();

            ToPostFix();
        }

        internal IList<IRulePart> RuleParts { get => _rule_parts; }
        internal IList<IRulePart> PostFixParts { get => _post_fix_parts; }
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

        public void Mutate(float seed)
        {
            var set = new SortedSet<IResultFuzzyMember>(Result.ParentSet.Members);
            var sb = new StringBuilder();

            if (seed < 0.5f)
                _result = set.Where(x => x.Peak < Result.Peak).FirstOrDefault() ?? _result;
            else
                _result = set.Where(x => x.Peak > Result.Peak).FirstOrDefault() ?? _result;

            foreach (var rulePart in _rule_parts)
                sb.Append(rulePart.ToString()).Append("  ");
            sb.Append(" => ").Append(_result.ToString());

            _print_output = sb.ToString();
        }
    }
}
