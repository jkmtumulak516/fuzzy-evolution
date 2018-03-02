using System;

namespace FuzzyLogicSystems.Core.Values
{
    // class for containing fuzzymembers that fuzzifiy crisp values
    public interface IResultFuzzyMember : IFuzzyMember<IResultFuzzyMember>, IComparable<IResultFuzzyMember>
    {
        float GetArea(float degree);
    }

}
