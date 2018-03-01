using System.Linq;
using System.Collections.Generic;
using EvolutionaryAlgorithms.Genetic;

namespace TestEvolutionaryAlgorithms.Genetic
{
    public class DummyOrganism : IOrganism<DummyOrganism, DummyGene>
    {
        private readonly float _fitness;
        private readonly List<DummyGene> _genes;

        public DummyOrganism(float fitness, IList<int> list)
        {
            _fitness = fitness;
            _genes = (from x in list select x).ToList().ConvertAll(x => new DummyGene(x));
        }

        public DummyOrganism(float fitness, IList<DummyGene> list)
        {
            _fitness = fitness;
            _genes = (from x in list select x).ToList();
        }

        public float Fitness { get => _fitness; }
        public List<DummyGene> Genes { get => _genes; }
    }
}
