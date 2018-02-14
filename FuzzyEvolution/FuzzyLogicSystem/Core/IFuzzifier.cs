using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzifier
    {
        IDictionary<int, IList<FuzzyValue<InputFuzzyMember>>> Fuzzify(IDictionary<int, float> crispValues, IDictionary<int, FuzzySet<InputFuzzyMember>> fuzzySets);
    }
}
