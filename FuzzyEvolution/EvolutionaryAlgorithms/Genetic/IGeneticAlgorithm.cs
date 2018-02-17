using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IGeneticAlgorithm<T> where T : IOrganism
    {
        ISelectionMethod SelectionMethod { get; }
        ICrossoverMethod CrossoverMethod { get; }

        IList<T> BreedNewGeneration(IList<T> population);
    }
}
