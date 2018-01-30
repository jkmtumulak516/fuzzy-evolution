using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    interface IFuzzifier
    {
        Dictionary<int, List<FuzzyValue<InputFuzzyMember>>> Fuzzify(IDictionary<int, float> crispValues, IDictionary<int, FuzzySet> fuzzySets);
    }
}
