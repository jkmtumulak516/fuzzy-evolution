using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public class GaussianInput : InputFuzzyMember
    {
        public GaussianInput(string name, FuzzySet<InputFuzzyMember> containingSet, float peak,
            bool ceilLeft, bool ceilRight, float baseHalfWidth, float peakHalfWidth) 
            : base(name, containingSet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth) { }

        public override float GetMembership(float crispValue)
        {
            if (CeilLeft && crispValue < Peak) return 1.0f;
            else if (CeilRight && crispValue > Peak) return 1.0f;
            else if (Math.Abs(Peak - crispValue) <= PeakHalfWidth) return 1.0f;

            float effectivePeak = crispValue < Peak ? Peak - PeakHalfWidth : Peak + PeakHalfWidth;

            return MathUtil.GaussianDistance(1.0f, effectivePeak, (BaseHalfWidth - PeakHalfWidth) * 2.0f, crispValue);
        }
    }
}
