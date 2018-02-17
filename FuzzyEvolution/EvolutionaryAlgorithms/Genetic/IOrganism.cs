using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IOrganism : IMutatable
    {
        float Fitness { get; }
        IList<IGene> Genes { get; }
    }
}
