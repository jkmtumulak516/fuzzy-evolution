using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    public class Rule
    {
        private readonly List<IRulePart> _rule_parts;
        private readonly List<IRulePart> _post_fix_parts;
        private readonly HashSet<int> _categories;
        private readonly ResultFuzzyMember _result;

        internal Rule(List<IRulePart> ruleParts, HashSet<int> categories, ResultFuzzyMember result)
        {
            _rule_parts = ruleParts;
            _post_fix_parts = new List<IRulePart>(ruleParts.Count);

            _categories = categories;

            _result = result;

            ToPostFix();
        }

        private List<IRulePart> RuleParts { get => _rule_parts; }
        private List<IRulePart> PostFixParts { get => _post_fix_parts; }
        public HashSet<int> Categories { get => _categories; }
        public ResultFuzzyMember Result { get => _result; }

        public FuzzyValue Evaluate(IDictionary<int, string> fuzzifiedValues, float degree)
        {
            var operandStack = new Stack<bool>();

            foreach (IRulePart part in RuleParts)
                part.Evaluate(fuzzifiedValues, operandStack);

            bool outcome = operandStack.Pop();

            return outcome ? new FuzzyValue(degree, Result) : null;
        }

        internal void ToPostFix()
        {
            var operandStack = new Stack<RuleOperator>();

            foreach (IRulePart part in RuleParts)
                part.ToPostFix(PostFixParts, operandStack);

            while (operandStack.Count > 0)
                PostFixParts.Add(operandStack.Pop());
        }
    }
}
