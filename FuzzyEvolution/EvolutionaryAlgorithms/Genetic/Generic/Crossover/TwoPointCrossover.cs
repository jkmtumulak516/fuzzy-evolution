using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic.Generic.Crossover
{
    public class TwoPointCrossover : ICrossoverMethod
    {
        private readonly Random _random;

        private TwoPointCrossover()
        {
            _random = new Random();
        }

        public Tuple<O, O> CrossoverGenes<O, G>(O o1, O o2, IOrganismFactory<O, G> organismFactory, IGeneCopier<G> geneCopier)
            where O : IOrganism<O, G>
            where G : IGene<G>
        {
            var smallGenes = o1.Genes.Count < o2.Genes.Count ? o1.Genes : o2.Genes;
            var bigGenes = o1.Genes.Count < o2.Genes.Count ? o2.Genes : o1.Genes;

            int firstCrossoverPoint = _random.Next(smallGenes.Count - 3);
            int secondCrossoverPoint = _random.Next(smallGenes.Count - firstCrossoverPoint - 1) + firstCrossoverPoint;

            var firstGeneSet = new List<G>(smallGenes.Count);
            var secondGeneSet = new List<G>(bigGenes.Count);

            firstGeneSet.AddRange(
                smallGenes.GetRange(0, firstCrossoverPoint + 1)
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            secondGeneSet.AddRange(
                bigGenes.GetRange(0, firstCrossoverPoint + 1)
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            firstGeneSet.AddRange(
                bigGenes.GetRange(firstCrossoverPoint + 1, firstCrossoverPoint + secondCrossoverPoint)
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            secondGeneSet.AddRange(
                smallGenes.GetRange(firstCrossoverPoint + 1, firstCrossoverPoint + secondCrossoverPoint)
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            firstGeneSet.AddRange(
                smallGenes.GetRange(secondCrossoverPoint + 1, smallGenes.Count - (firstCrossoverPoint + 1))
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            secondGeneSet.AddRange(
                bigGenes.GetRange(secondCrossoverPoint + 1, bigGenes.Count - (firstCrossoverPoint + 1))
                .ConvertAll(x => geneCopier.DeepCopy(x)));

            return new Tuple<O, O>(organismFactory.Make(firstGeneSet), organismFactory.Make(secondGeneSet));
        }
    }
}
