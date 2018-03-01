using System.Collections.Generic;
using EvolutionaryAlgorithms.Genetic;

namespace TestEvolutionaryAlgorithms.Genetic
{
    public class DummyOrganismFactory : IOrganismFactory<DummyOrganism, DummyGene>
    {
        public DummyOrganism Make(IList<DummyGene> genes)
        {
            return new DummyOrganism(0f, genes);
        }
    }
}
