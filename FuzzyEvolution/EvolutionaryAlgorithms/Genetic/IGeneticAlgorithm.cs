using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IGeneticAlgorithm<T> where T : IOrganism
    {
        ISelectionMethod SelectionMethod { get; }
        ICrossoverMethod CrossoverMethod { get; }

        IList<T> BreedNewGeneration(IList<T> population);
    }
}
