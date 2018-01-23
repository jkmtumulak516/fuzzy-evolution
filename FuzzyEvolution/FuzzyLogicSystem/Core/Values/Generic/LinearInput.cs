using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public class LinearInput : InputFuzzyMember
    {
        public LinearInput(string name, int category, float center, 
            bool ceilLeft, bool ceilRight, float coverage, float upperCoverage) 
            : base(name, category, center, ceilLeft, ceilRight, coverage, upperCoverage) { }

        public override float GetMembership(float crispValue)
        {
            float diffInCenterAndValue = Math.Abs(Center - crispValue);

            if (CeilLeft && crispValue < Center) return 1.0f;
            else if (CeilRight && crispValue > Center) return 1.0f;
            else if (diffInCenterAndValue <= UpperCoverage) return 1.0f;
            
            float effectiveCenter = crispValue < Center ? Center - UpperCoverage : Center + UpperCoverage;

            return diffInCenterAndValue < Coverage ? MathUtil.LinearDistance(effectiveCenter, crispValue) : 0.0f;
        }
    }
}
