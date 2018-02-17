using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.Genetic.Generic
{
    public class GeneticAlgorithm<T> : IGeneticAlgorithm<T> where T : IOrganism
    {
        private readonly ISelectionMethod _selector;
        private readonly ICrossoverMethod _crossover;

        public GeneticAlgorithm(ISelectionMethod selectionMethod, ICrossoverMethod crossoverMethod)
        {
            _selector = selectionMethod;
            _crossover = crossoverMethod;
        }

        public ISelectionMethod SelectionMethod { get => _selector; }
        public ICrossoverMethod CrossoverMethod { get => _crossover; }

        public IList<T> BreedNewGeneration(IList<T> population)
        {
            var pairings = SelectionMethod.SelectPairings(population);

            var newGeneration = new List<T>(population.Count);

            foreach (var pairing in pairings)
            {
                var newPair = CrossoverMethod.CrossoverPairings(pairing.Item1, pairing.Item2);

                newGeneration.Add(newPair.Item1);
                newGeneration.Add(newPair.Item2);
            }

            return newGeneration;
        }
    }
}
