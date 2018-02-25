using System.Collections.Generic;
using System;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyLogicSystem
    {
        IFuzzifier Fuzzifier { get; }
        IDefuzzifier Defuzzifier { get; }
        IFuzzyRuleBase RuleBase { get; }

        float Evaluate(IDictionary<int, float> crispValues, out IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzified, out IList<FuzzyValue<IResultFuzzyMember>> evaluated);
    }
}
