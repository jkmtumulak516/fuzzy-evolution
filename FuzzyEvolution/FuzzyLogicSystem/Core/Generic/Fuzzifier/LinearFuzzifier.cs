using System;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Generic.Fuzzifier
{
    public class LinearFuzzifier : IFuzzifier
    {
        public IDictionary<int, IList<FuzzyValue<InputFuzzyMember>>> Fuzzify(IDictionary<int, float> crispValues, IDictionary<int, FuzzySet<InputFuzzyMember>> fuzzySets)
        {
            var fuzzifiedValues = new Dictionary<int, IList<FuzzyValue<InputFuzzyMember>>>();

            foreach (var crispValue in crispValues)
            {
                var fuzzySet = fuzzySets[crispValue.Key];
                var currentValues = new List<FuzzyValue<InputFuzzyMember>>();

                foreach (var fuzzyMember in fuzzySet.Members)
                {
                    if (fuzzyMember.Contains(crispValue.Value))
                        currentValues.Add(new FuzzyValue<InputFuzzyMember>
                            (Membership(fuzzyMember, crispValue.Value), fuzzyMember));
                }

                fuzzifiedValues.Add(crispValue.Key, currentValues);
            }

            return fuzzifiedValues;
        }

        private float Membership(InputFuzzyMember fuzzyMember, float crispValue)
        {
            float diffInCenterAndValue = Math.Abs(fuzzyMember.Peak - crispValue);

            if (fuzzyMember.CeilLeft && crispValue < fuzzyMember.Peak) return 1.0f;
            else if (fuzzyMember.CeilRight && crispValue > fuzzyMember.Peak) return 1.0f;
            else if (diffInCenterAndValue <= fuzzyMember.PeakHalfWidth) return 1.0f;

            float effectiveCenter = crispValue < fuzzyMember.Peak 
                ? fuzzyMember.Peak - fuzzyMember.PeakHalfWidth 
                : fuzzyMember.Peak + fuzzyMember.PeakHalfWidth;

            return diffInCenterAndValue < fuzzyMember.BaseHalfWidth ? MathUtil.LinearDistance(effectiveCenter, crispValue) : 0.0f;
        }
    }
}
