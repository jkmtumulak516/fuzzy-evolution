using System.Collections.Generic;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyLogicSystem
    {
        IFuzzifier Fuzzifier { get; }
        IDefuzzifier Defuzzifier { get; }
        IFuzzyRuleBase RuleBase { get; }

        float Evaluate(IDictionary<int, float> crispValues);
    }
}
