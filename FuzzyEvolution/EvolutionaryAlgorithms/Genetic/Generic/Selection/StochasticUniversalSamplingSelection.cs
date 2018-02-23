using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionaryAlgorithms.Genetic.Generic.Selection
{
    public class StochasticUniversalSamplingSelection : ISelectionMethod
    {
        private readonly float _min_increment;
        private readonly float _max_increment;
        private readonly Random _random;

        private StochasticUniversalSamplingSelection(float minIncrement, float maxIncrement)
        {
            if (minIncrement < 0f || minIncrement > 1f) throw new ArgumentException("Parameter Minimum Increment must range between 0.00 and 1.00 inclusive.");
            if (maxIncrement < 0f || maxIncrement > 1f) throw new ArgumentException("Parameter Maximum Increment must range between 0.00 and 1.00 inclusive.");
            if (minIncrement > maxIncrement) throw new ArgumentException("Parameter Minimum Increment must be less than or equal to Maximum Increment.");

            _min_increment = minIncrement;
            _max_increment = maxIncrement;

            _random = new Random();
        }

        public float MinimumIncrement { get => _min_increment; }
        public float MaximumIncrement { get => _max_increment; }

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

            float pointer = (float)_random.NextDouble() * totalFitness;
            float increment = ((float)_random.NextDouble() * (MaximumIncrement - MinimumIncrement)) + MinimumIncrement;
            int quota = population.Count >> 1 + ((population.Count & 1) == 1 ? 1 : 0 );
            var result = new List<Tuple<O, O>>(quota);

            for (int i = 0; i < quota; i++)
            {
                int firstIndex = BinarySearchIndex(pointer, fitnessIncrements);
                pointer = (pointer + increment) % totalFitness;
                int secondIndex = BinarySearchIndex(pointer, fitnessIncrements);
                pointer = (pointer + increment) % totalFitness;

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
