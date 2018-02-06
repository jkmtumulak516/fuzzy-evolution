using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public class LinearResult : ResultFuzzyMember
    {
        public LinearResult(string name, FuzzySet<ResultFuzzyMember> containingSet, float center,
            float coverage, float upperCoverage = 0.0f) 
            : base(name, containingSet, center, coverage, upperCoverage) { }

        // degree is assumed to be a value between 0 and 1 representing a percentage
        public override float GetArea(float degree)
        {
            float effectiveCoverage = BaseHalfWidth * 2;
            float effectiveUpperCoverage = PeakHalfWidth * 2;

            if (degree > 1.0f || degree < 0.0f) throw new ArgumentException
                    ("Parameter 'degree' must be a value between 0 and 1 inclusive. [degree = " + degree.ToString() + "]");
            else if (degree == 1.0f)
                return MathUtil.ParallelTrapezoidalArea(1.0f, PeakHalfWidth + PeakHalfWidth, BaseHalfWidth + BaseHalfWidth);
            else
                return MathUtil.ParallelTrapezoidalArea(1.0f,
                    effectiveUpperCoverage + (effectiveCoverage - effectiveUpperCoverage) * (1.0f - degree),
                    effectiveCoverage);
        }
    }
}
