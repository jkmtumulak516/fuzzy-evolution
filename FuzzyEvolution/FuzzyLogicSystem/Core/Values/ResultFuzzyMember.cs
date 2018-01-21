
namespace FuzzyLogicSystems.Core.Values
{
    public abstract class ResultFuzzyMember : FuzzyMember
    {
        public ResultFuzzyMember(string name, int category, float center,
            float coverage, float upperCoverage = 0.0f) 
            : base(name, category, center, coverage, upperCoverage) { }

        public abstract float GetArea(float degree);
    }
}
