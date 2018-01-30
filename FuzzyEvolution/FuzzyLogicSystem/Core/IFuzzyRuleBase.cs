using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    interface IFuzzyRuleBase
    {
        List<FuzzyValue<ResultFuzzyMember>> Evaluate(IDictionary<int, IList<FuzzyValue<InputFuzzyMember>>> fuzzyValues);
    }
}
