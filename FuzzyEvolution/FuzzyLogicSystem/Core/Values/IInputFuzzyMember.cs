
namespace FuzzyLogicSystems.Core.Values
{
    // class for containing fuzzymembers that fuzzifiy crisp values
    public interface IInputFuzzyMember : IFuzzyMember
    {
        bool CeilLeft { get; }
        bool CeilRight { get; }

        float GetMembership(float crispValue);
    }
}
