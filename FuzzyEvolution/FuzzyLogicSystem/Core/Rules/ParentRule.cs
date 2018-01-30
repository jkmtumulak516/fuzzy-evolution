using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    public class ParentRule : Rule
    {
        internal ParentRule(List<IRulePart> ruleParts, HashSet<int> categories, ResultFuzzyMember result) 
            : base(ruleParts, categories, result) { }

        public List<SubRule> SubRules()
        {
            var result = new List<SubRule>();
            var currentSubRule = new List<IRulePart>();

            foreach(var rulePart in RuleParts)
            {
                RuleOperator ruleOperator = null;

                if ((ruleOperator = rulePart as RuleOperator) != null)
                {
                    if (ruleOperator.OperatorType == BooleanOperator.OR)
                    {
                        result.Add(new SubRule(currentSubRule, this));
                        currentSubRule = new List<IRulePart>();
                    }

                    else currentSubRule.Add(rulePart);
                }

                else currentSubRule.Add(rulePart);
            }

            if (currentSubRule.Count > 0)
                result.Add(new SubRule(currentSubRule, this));

            return result;
        }
    }
}
