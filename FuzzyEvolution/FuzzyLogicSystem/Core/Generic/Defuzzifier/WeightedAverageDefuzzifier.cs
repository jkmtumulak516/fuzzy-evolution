using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.Defuzzifier
{
    public class WeightedAverageDefuzzifier : IDefuzzifier
    {
        public float Defuzzify(IList<FuzzyValue<IResultFuzzyMember>> results)
        {
            float sum = 0.0f;

            foreach (var fuzzyValue in results)
                sum += fuzzyValue.Degree * fuzzyValue.FuzzyMember.Peak;

            return sum / results.Count;
        }
    }
}
