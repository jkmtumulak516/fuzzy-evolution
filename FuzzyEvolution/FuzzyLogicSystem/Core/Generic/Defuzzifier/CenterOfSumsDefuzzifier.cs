using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.Defuzzifier
{
    public class CenterOfSumsDefuzzifier : IDefuzzifier
    {
        public float Defuzzify(IList<FuzzyValue<IResultFuzzyMember>> results)
        {
            float weightedAreaSum = 0.0f;
            float areaSum = 0.0f;

            foreach (var fuzzyValue in results)
            {
                float area = fuzzyValue.FuzzyMember.GetArea(fuzzyValue.Degree);

                weightedAreaSum += fuzzyValue.FuzzyMember.Peak * area;
                areaSum += area;
            }

            return weightedAreaSum / areaSum;
        }
    }
}
