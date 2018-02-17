using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IGene : IMutatable
    {
        IList<ISubGene> SubGenes { get; }
    }
}
