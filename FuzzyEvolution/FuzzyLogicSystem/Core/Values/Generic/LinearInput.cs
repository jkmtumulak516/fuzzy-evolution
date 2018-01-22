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
            return Math.Abs(Center - crispValue) < Coverage ? MathUtil.LinearDistance(Center, crispValue) : 0.0f;
        }
    }
}
