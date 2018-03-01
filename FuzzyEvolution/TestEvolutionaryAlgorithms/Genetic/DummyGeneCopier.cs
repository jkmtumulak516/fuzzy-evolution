using EvolutionaryAlgorithms.Genetic;

namespace TestEvolutionaryAlgorithms.Genetic
{
    public class DummyGeneCopier : IGeneCopier<DummyGene>
    {
        public DummyGene DeepCopy(DummyGene gene)
        {
            return new DummyGene(gene.Value);
        }
    }
}
