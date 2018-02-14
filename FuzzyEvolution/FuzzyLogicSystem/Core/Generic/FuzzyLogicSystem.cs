using System.Collections.Generic;

namespace FuzzyLogicSystems.Core.Generic
{
    public class FuzzyLogicSystem : IFuzzyLogicSystem
    {
        private readonly IFuzzifier _fuzzifier;
        private readonly IDefuzzifier _defuzzifier;
        private readonly IFuzzyRuleBase _rule_base;

        public FuzzyLogicSystem(IFuzzifier fuzzifier, IDefuzzifier defuzzifier, IFuzzyRuleBase ruleBase)
        {
            _fuzzifier = fuzzifier;
            _defuzzifier = defuzzifier;
            _rule_base = ruleBase;
        }

        public IFuzzifier Fuzzifier { get => _fuzzifier; }
        public IDefuzzifier Defuzzifier{ get => _defuzzifier; }
        public IFuzzyRuleBase RuleBase { get => _rule_base; }

        public float Evaluate(IDictionary<int, float> crispValues)
        {
            var fuzzifiedValues = Fuzzifier.Fuzzify(crispValues, RuleBase.InputFuzzySets);
            var evaluatedValues = RuleBase.Evaluate(fuzzifiedValues);
            var defuzzifiedValue = Defuzzifier.Defuzzify(evaluatedValues);

            return defuzzifiedValue;
        }
    }
}
