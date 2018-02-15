using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    public class ParentRule : Rule
    {
        internal ParentRule(IList<IRulePart> ruleParts, IResultFuzzyMember result) 
            : base(ruleParts, result) { }

        public List<SubRule> SubRules()
        {
            var subRules = new List<SubRule>();
            int startIndex = 0;
            int count = 0;
            RuleOperator ruleOperator = null;

            foreach (var rulePart in RuleParts)
            {
                if ((ruleOperator = rulePart as RuleOperator) != null && ruleOperator.OperatorType == BooleanOperator.OR)
                {
                    subRules.Add(new SubRule(((List<IRulePart>)RuleParts).GetRange(startIndex, count), this));
                    startIndex = count + 1;
                    count = 0;
                }

                else count++;
            }

            subRules.Add(new SubRule(((List<IRulePart>)RuleParts).GetRange(startIndex, count), this));

            return subRules;
        }
    }
}
