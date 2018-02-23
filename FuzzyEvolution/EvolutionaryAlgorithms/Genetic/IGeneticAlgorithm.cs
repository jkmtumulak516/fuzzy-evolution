using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IGeneticAlgorithm<O, G> where O : IOrganism<O, G> where G : IGene<G>
    {
        ISelectionMethod SelectionMethod { get; }
        ICrossoverMethod CrossoverMethod { get; }

        IList<O> BreedNewGeneration(IList<O> population, float mutationChance);
    }
}
