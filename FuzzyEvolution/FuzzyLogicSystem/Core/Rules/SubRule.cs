using System.Collections.Generic;
using FuzzyLogicSystems.Core.Rules.Exception;

namespace FuzzyLogicSystems.Core.Rules
{
    public class SubRule : Rule
    {
        private readonly Rule _parent;
        private readonly IDictionary<int, RuleOperand> _variables;

        internal SubRule(IList<IRulePart> ruleParts, Rule parent)
            : base(ruleParts, parent.Result)
        {
            _parent = parent;
            _variables = new Dictionary<int, RuleOperand>();

            foreach (var rulePart in ruleParts)
            {
                if (rulePart is RuleOperand)
                {
                    var ruleOperand = rulePart as RuleOperand;
                    int category = ruleOperand.FuzzyMember.Category;

                    if (!_variables.ContainsKey(category))
                        _variables.Add(category, ruleOperand);

                    else
                        throw new RuleSyntaxException("");
                }
            }
        }

        internal RuleOperand this[int category] { get => _variables.ContainsKey(category) ? _variables[category] : null; }
        internal ICollection<int> Categories { get => _variables.Keys; }
        internal Rule Parent { get => _parent; }
    }
}
