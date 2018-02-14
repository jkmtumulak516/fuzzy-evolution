using System;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Generic.Fuzzifier
{
    public class GaussianFuzzifier : IFuzzifier
    {
        public IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> Fuzzify(IDictionary<int, float> crispValues, IDictionary<int, FuzzySet<IInputFuzzyMember>> fuzzySets)
        {
            var fuzzifiedValues = new Dictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>();

            foreach (var crispValue in crispValues)
            {
                var fuzzySet = fuzzySets[crispValue.Key];
                var currentValues = new List<FuzzyValue<IInputFuzzyMember>>();

                foreach (var fuzzyMember in fuzzySet.Members)
                {
                    if (fuzzyMember.Contains(crispValue.Value))
                        currentValues.Add(new FuzzyValue<IInputFuzzyMember>
                            (Membership(fuzzyMember, crispValue.Value), fuzzyMember));
                }

                fuzzifiedValues.Add(crispValue.Key, currentValues);
            }

            return fuzzifiedValues;
        }

        private float Membership(IInputFuzzyMember fuzzyMember, float crispValue)
        {
            if (fuzzyMember.CeilLeft && crispValue < fuzzyMember.Peak) return 1.0f;
            else if (fuzzyMember.CeilRight && crispValue > fuzzyMember.Peak) return 1.0f;
            else if (Math.Abs(fuzzyMember.Peak - crispValue) <= fuzzyMember.PeakHalfWidth) return 1.0f;

            float effectivePeak = crispValue < fuzzyMember.Peak 
                ? fuzzyMember.Peak - fuzzyMember.PeakHalfWidth 
                : fuzzyMember.Peak + fuzzyMember.PeakHalfWidth;

            return MathUtil.GaussianDistance
                (1.0f, effectivePeak, (fuzzyMember.BaseHalfWidth - fuzzyMember.PeakHalfWidth) * 2.0f, crispValue);
        }
    }
}
