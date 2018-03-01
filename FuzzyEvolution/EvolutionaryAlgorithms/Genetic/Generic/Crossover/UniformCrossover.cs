using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic.Generic.Crossover
{
    public class UniformCrossover : ICrossoverMethod
    {
        private readonly Random _random;

        public UniformCrossover()
        {
            _random = new Random();
        }

        public Tuple<O, O> CrossoverGenes<O, G>(O o1, O o2, IOrganismFactory<O, G> organismFactory, IGeneCopier<G> geneCopier)
            where O : IOrganism<O, G>
            where G : IGene<G>
        {
            var smallGenes = o1.Genes.Count < o2.Genes.Count ? o1.Genes : o2.Genes;
            var bigGenes = o1.Genes.Count < o2.Genes.Count ? o2.Genes : o1.Genes;

            var firstGeneSet = new List<G>(smallGenes.Count);
            var secondGeneSet = new List<G>(bigGenes.Count);

            bool reverse = _random.NextDouble() < 0.5;

            for (int i = 0; i < smallGenes.Count; i++)
            {
                if (!reverse)
                {
                    firstGeneSet.Add(geneCopier.DeepCopy(smallGenes[i]));
                    secondGeneSet.Add(geneCopier.DeepCopy(bigGenes[i]));
                }
                else
                {
                    firstGeneSet.Add(geneCopier.DeepCopy(bigGenes[i]));
                    secondGeneSet.Add(geneCopier.DeepCopy(smallGenes[i]));
                }

                reverse = _random.NextDouble() < 0.5;
            }

            if (bigGenes.Count > smallGenes.Count)
            {
                for (int i = smallGenes.Count; i < bigGenes.Count; i++)
                {
                    if (!reverse)
                        firstGeneSet.Add(geneCopier.DeepCopy(bigGenes[i]));
                    else
                        secondGeneSet.Add(geneCopier.DeepCopy(bigGenes[i]));

                    reverse = _random.NextDouble() < 0.5;
                }
            }

            return new Tuple<O, O>(organismFactory.Make(firstGeneSet), organismFactory.Make(secondGeneSet));
        }
    }
}
