using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IOrganismFactory<O, G> where O : IOrganism<O, G> where G : IGene<G>
    {
        O Make(IList<G> genes);
    }
}
