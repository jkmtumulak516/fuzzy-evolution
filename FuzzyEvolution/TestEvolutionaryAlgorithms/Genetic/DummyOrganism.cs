using System;
using System.Collections.Generic;
using EvolutionaryAlgorithms.Genetic;

namespace TestEvolutionaryAlgorithms.Genetic
{
    public class DummyOrganism : IOrganism<DummyOrganism, DummyGene>
    {
        private readonly float _fitness;
        private readonly List<DummyGene> _genes;

        public DummyOrganism(float fitness, List<int> list)
        {
            _fitness = fitness;
            _genes = list.ConvertAll(x => new DummyGene(x));
        }

        public DummyOrganism(float fitness, List<DummyGene> list)
        {
            _fitness = fitness;
            _genes = list;
        }

        public float Fitness { get => _fitness; }
        public IList<DummyGene> Genes { get => _genes; }
    }
}
