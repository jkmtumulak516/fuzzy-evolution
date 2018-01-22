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
            return MathUtil.GaussianDistance(1.0f, Center, Coverage * 2.0f, crispValue);
        }
    }
}
