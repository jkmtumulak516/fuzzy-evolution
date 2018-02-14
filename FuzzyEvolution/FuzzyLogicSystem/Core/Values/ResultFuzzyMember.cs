
namespace FuzzyLogicSystems.Core.Values
{
    public abstract class ResultFuzzyMember : FuzzyMember
    {
        public ResultFuzzyMember(string name, FuzzySet<ResultFuzzyMember> containingSet, float peak,
            float baseHalfWidth, float peakHalfWidth = 0.0f) 
            : base(name, containingSet.Category, peak, baseHalfWidth, peakHalfWidth) { }

        public abstract float GetArea(float degree);
    }
}
