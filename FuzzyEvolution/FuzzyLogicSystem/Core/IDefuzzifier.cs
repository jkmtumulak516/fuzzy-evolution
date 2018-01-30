using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    interface IDefuzzifier
    {
        float Defuzzify(IList<FuzzyValue<ResultFuzzyMember>> results);
    }
}
