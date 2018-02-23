using System;
using System.Linq;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic.Generic.Selection
{
    public class FitnessProportionateSelection : ISelectionMethod
    {
        private readonly Random _random;

        private FitnessProportionateSelection()
        {
            _random = new Random();
        }

        public IList<Tuple<O, O>> SelectPairings<O, G>(IList<O> population)
            where O : IOrganism<O, G>
            where G : IGene<G>
        {
            float totalFitness = (from organism in population select organism.Fitness).Sum();
            var sortedPopulation = (from organism in population select organism).OrderBy(x => x.Fitness).ToList();

            var fitnessIncrements = new List<float>(population.Count);

            float recent = 0f;
            foreach (var organism in sortedPopulation)
            {
                fitnessIncrements.Add(organism.Fitness + recent);
                recent += organism.Fitness;
            }

            int quota = population.Count >> 1 + ((population.Count & 1) == 1 ? 1 : 0);
            var result = new List<Tuple<O, O>>(quota);

            for (int i = 0; i < quota; i++)
            {
                int firstIndex = BinarySearchIndex((float)_random.NextDouble() * totalFitness, fitnessIncrements);
                int secondIndex = BinarySearchIndex((float)_random.NextDouble() * totalFitness, fitnessIncrements);

                result.Add(new Tuple<O, O>(population[firstIndex], population[secondIndex]));
            }

            return result;
        }

        private int BinarySearchIndex(float value, List<float> list)
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) >> 1;
                float current = list[mid];

                if (current > value)
                {
                    if (mid > 0)
                    {
                        float belowCurrent = list[mid - 1];

                        if (belowCurrent < value)
                            return mid;
                        else
                            high = mid - 1;
                    }

                    else
                        return mid;
                }
                else if (current < value)
                    low = mid + 1;
                else
                    return mid;
            }

            return low;
        }
    }
}
