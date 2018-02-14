using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.Fuzzifier
{
    public class Fuzzifier : IFuzzifier
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
                            (fuzzyMember.GetMembership(crispValue.Value), fuzzyMember));
                }

                fuzzifiedValues.Add(crispValue.Key, currentValues);
            }

            return fuzzifiedValues;
        }
    }
}
