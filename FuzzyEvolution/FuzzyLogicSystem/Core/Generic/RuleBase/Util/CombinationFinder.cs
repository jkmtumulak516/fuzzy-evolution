using System.Collections.Generic;
using System.Linq;

namespace FuzzyLogicSystems.Core.Generic.RuleBase.Util
{
    public class CombinationFinder
    {
        public IList<IList<T>> FindCombinations<T>(IList<IList<T>> listOfLists)
        {
            var combinations = new List<IList<T>>();

            // prime the data
            foreach (var value in listOfLists[0])
                combinations.Add(new List<T> { value });

            foreach (var set in listOfLists.Skip(1))
            {
                IEnumerable<IList<T>> temp = from value in set
                           from combination in combinations
                           select new List<T>(combination) { value };

                combinations = temp.ToList();
            }

            return combinations;
        }
    }
}
