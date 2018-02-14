
namespace FuzzyLogicSystems.Core.Values
{
    // class for containing fuzzymembers that fuzzifiy crisp values
    public interface IResultFuzzyMember : IFuzzyMember
    {
        float GetArea(float degree);
    }

}
