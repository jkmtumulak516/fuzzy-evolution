using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Generic.Fuzzifier
{
    class Fuzzifier : IFuzzifier
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
                            (fuzzyMember.GetMembership(crispValue.Value), fuzzyMember));
                }

                fuzzifiedValues.Add(crispValue.Key, currentValues);
            }

            return fuzzifiedValues;
        }
    }
}
