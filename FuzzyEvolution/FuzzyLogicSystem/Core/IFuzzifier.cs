using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzifier
    {
        IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> Fuzzify(IDictionary<int, float> crispValues, IDictionary<int, FuzzySet<IInputFuzzyMember>> fuzzySets);
    }
}
