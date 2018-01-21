
namespace FuzzyLogicSystem.Core.Values
{
    public interface IFuzzyMember
    {
        string Name { get; }
        int Category { get; }
        float Center { get; }
        float Coverage { get; }
        float UpperCoverage { get; }
    }
}
