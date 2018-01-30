using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.Defuzzifier
{
    class WeightedAverageDefuzzifier : IDefuzzifier
    {
        public float Defuzzify(IList<FuzzyValue<ResultFuzzyMember>> results)
        {
            float sum = 0.0f;

            foreach (var fuzzyValue in results)
                sum += fuzzyValue.Degree * fuzzyValue.FuzzyMember.Peak;

            return sum / results.Count;
        }
    }
}
