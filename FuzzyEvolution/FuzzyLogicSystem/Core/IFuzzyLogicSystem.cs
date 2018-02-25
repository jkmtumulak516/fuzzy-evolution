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

        Tuple<float, IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>, IList<FuzzyValue<IResultFuzzyMember>>> Evaluate(IDictionary<int, float> crispValues);
    }
}
