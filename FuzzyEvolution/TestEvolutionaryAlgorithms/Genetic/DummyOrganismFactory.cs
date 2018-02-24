using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolutionaryAlgorithms.Genetic;

namespace TestEvolutionaryAlgorithms.Genetic
{
    public class DummyOrganismFactory : IOrganismFactory<DummyOrganism, DummyGene>
    {
        public DummyOrganism Make(IList<DummyGene> genes)
        {
            throw new NotImplementedException();
        }
    }
}
