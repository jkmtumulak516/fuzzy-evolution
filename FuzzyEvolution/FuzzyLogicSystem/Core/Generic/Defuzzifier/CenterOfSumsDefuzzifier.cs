using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.Defuzzifier
{
    class CenterOfSumsDefuzzifier : IDefuzzifier
    {
        public float Defuzzify(IList<FuzzyValue<ResultFuzzyMember>> results)
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
