using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public class LinearResult : ResultFuzzyMember
    {
        public LinearResult(string name, int category, float center,
            float coverage, float upperCoverage = 0.0f) 
            : base(name, category, center, coverage, upperCoverage) { }

        // degree is assumed to be a value between 0 and 1 representing a percentage
        public override float GetArea(float degree)
        {
            return MathUtil.ParallelTrapezoidalArea(1.0f, UpperCoverage, Coverage)
                - MathUtil.ParallelTrapezoidalArea(1.0f - degree, UpperCoverage, Coverage * degree);
        }
    }
}
