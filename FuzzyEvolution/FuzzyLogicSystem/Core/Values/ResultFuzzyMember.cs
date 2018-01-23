
namespace FuzzyLogicSystems.Core.Values
{
    public abstract class ResultFuzzyMember : FuzzyMember
    {
        public ResultFuzzyMember(string name, int category, float peak,
            float baseHalfWidth, float peakHalfWidth = 0.0f) 
            : base(name, category, peak, baseHalfWidth, peakHalfWidth) { }

        public abstract float GetArea(float degree);
    }
}
