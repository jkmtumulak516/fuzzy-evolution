using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic.Generic.Crossover
{
    public class SinglePointCrossover : ICrossoverMethod
    {
        private readonly Random _random;

        private SinglePointCrossover()
        {
            _random = new Random();
        }

        public Tuple<O, O> CrossoverGenes<O, G>(O o1, O o2, IOrganismFactory<O, G> organismFactory, IGeneCopier<G> geneCopier)
            where O : IOrganism<O, G>
            where G : IGene<G>
        {
            var smallGenes = o1.Genes.Count < o2.Genes.Count ? o1.Genes : o2.Genes;
            var bigGenes = o1.Genes.Count < o2.Genes.Count ? o2.Genes : o1.Genes;

            int crossoverPoint = _random.Next(smallGenes.Count - 1);

            var firstGeneSet = new List<G>(smallGenes.Count);
            var secondGeneSet = new List<G>(bigGenes.Count);

            firstGeneSet.AddRange(
                smallGenes.GetRange(0, crossoverPoint + 1)
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            secondGeneSet.AddRange(
                bigGenes.GetRange(0, crossoverPoint + 1)
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            firstGeneSet.AddRange(
                bigGenes.GetRange(crossoverPoint + 1, bigGenes.Count - (crossoverPoint + 1))
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            secondGeneSet.AddRange(
                smallGenes.GetRange(crossoverPoint + 1, smallGenes.Count - (crossoverPoint + 1))
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            return new Tuple<O, O>(organismFactory.Make(firstGeneSet), organismFactory.Make(secondGeneSet));
        }
    }
}
