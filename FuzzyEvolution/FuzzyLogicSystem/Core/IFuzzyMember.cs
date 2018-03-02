using System;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyMember<T> : IEquatable<IFuzzyMember<T>> where T : IFuzzyMember<T>
    {
        string Name { get; }
        int Category { get; }
        FuzzySet<T> ParentSet { get; }
        float Peak { get; }
        float BaseHalfWidth { get; }
        float PeakHalfWidth { get; }
        
        bool Contains(float degree);
    }
}
