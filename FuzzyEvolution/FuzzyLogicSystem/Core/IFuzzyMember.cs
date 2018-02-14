using System;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyMember : IEquatable<IFuzzyMember>
    {
        string Name { get; }
        int Category { get; }
        float Peak { get; }
        float BaseHalfWidth { get; }
        float PeakHalfWidth { get; }
        
        bool Contains(float degree);
    }
}
