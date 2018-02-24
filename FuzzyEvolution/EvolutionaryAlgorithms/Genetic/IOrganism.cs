using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IOrganism<O, G> where O : IOrganism<O, G> where G : IGene<G>
    {
        float Fitness { get; }
        IList<G> Genes { get; }
    }
}
