using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public class GaussianInput : InputFuzzyMember
    {
        public GaussianInput(string name, int category, float center,
            bool ceilLeft, bool ceilRight, float coverage, float upperCoverage) 
            : base(name, category, center, ceilLeft, ceilRight, coverage, upperCoverage) { }

        public override float GetMembership(float crispValue)
        {
            if (CeilLeft && crispValue < Center) return 1.0f;
            else if (CeilRight && crispValue > Center) return 1.0f;
            else if (Math.Abs(Center - crispValue) <= UpperCoverage) return 1.0f;

            float effectiveCenter = crispValue < Center ? Center - UpperCoverage : Center + UpperCoverage;

            return MathUtil.GaussianDistance(1.0f, effectiveCenter, (Coverage - UpperCoverage) * 2.0f, crispValue);
        }
    }
}
