using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    public interface IDefuzzifier
    {
        float Defuzzify(IList<FuzzyValue<ResultFuzzyMember>> results);
    }
}
