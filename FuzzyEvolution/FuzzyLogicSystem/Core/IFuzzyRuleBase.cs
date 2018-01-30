using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    interface IFuzzyRuleBase
    {
        IList<FuzzyValue<ResultFuzzyMember>> Evaluate(IDictionary<int, IList<FuzzyValue<InputFuzzyMember>>> fuzzyValues);
        IDictionary<int, FuzzySet> InputFuzzySets { get;}
        FuzzySet ResultFuzzySet { get; }
    }
}
