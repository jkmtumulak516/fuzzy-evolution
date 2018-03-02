using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EvolutionaryAlgorithms.Genetic.Generic.Crossover;

namespace TestEvolutionaryAlgorithms.Genetic.Generic.Crossover
{
    [TestClass]
    public class TestTwoPointCrossover
    {
        [TestMethod]
        public void TwoPointCrossoverConstruction()
        {
            try
            {
                var crossover = new TwoPointCrossover();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TwoPointCrossoverEvenGenes()
        {
            var organism1 = new DummyOrganism(.25f, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var organism2 = new DummyOrganism(.75f, new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var crossover = new TwoPointCrossover();

            try
            {
                var children = crossover.CrossoverGenes(organism1, organism2, organismFactory, geneCopier);

                for (int i = 0; i < children.Item1.Genes.Count; i++)
                    Console.Write(children.Item1.Genes[i].Value + " ");
                Console.WriteLine();

                for (int i = 0; i < children.Item2.Genes.Count; i++)
                    Console.Write(children.Item2.Genes[i].Value + " ");
                Console.WriteLine();

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TwoPointCrossoverUnevenGenes()
        {
            var organism1 = new DummyOrganism(.25f, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 });
            var organism2 = new DummyOrganism(.75f, new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var crossover = new TwoPointCrossover();

            try
            {
                var children = crossover.CrossoverGenes(organism1, organism2, organismFactory, geneCopier);

                for (int i = 0; i < children.Item1.Genes.Count; i++)
                    Console.Write(children.Item1.Genes[i].Value + " ");
                Console.WriteLine();

                for (int i = 0; i < children.Item2.Genes.Count; i++)
                    Console.Write(children.Item2.Genes[i].Value + " ");
                Console.WriteLine();

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
