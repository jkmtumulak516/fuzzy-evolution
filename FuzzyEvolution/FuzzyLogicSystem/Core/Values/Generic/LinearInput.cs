using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public class LinearInput : InputFuzzyMember
    {
        public LinearInput(string name, FuzzySet<InputFuzzyMember> containingSet, float center, 
            bool ceilLeft, bool ceilRight, float coverage, float upperCoverage) 
            : base(name, containingSet, center, ceilLeft, ceilRight, coverage, upperCoverage) { }

        public override float GetMembership(float crispValue)
        {
            float diffInCenterAndValue = Math.Abs(Peak - crispValue);

            if (CeilLeft && crispValue < Peak) return 1.0f;
            else if (CeilRight && crispValue > Peak) return 1.0f;
            else if (diffInCenterAndValue <= PeakHalfWidth) return 1.0f;
            
            float effectiveCenter = crispValue < Peak ? Peak - PeakHalfWidth : Peak + PeakHalfWidth;

            return diffInCenterAndValue < BaseHalfWidth ? MathUtil.LinearDistance(effectiveCenter, crispValue) : 0.0f;
        }
    }
}
