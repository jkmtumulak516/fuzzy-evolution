using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EvolutionaryAlgorithms.Genetic.Generic.Crossover;

namespace TestEvolutionaryAlgorithms.Genetic.Generic.Crossover
{
    [TestClass]
    public class TestUniformCrossover
    {
        [TestMethod]
        public void UniformCrossoverConstruction()
        {
            try
            {
                var crossover = new UniformCrossover();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void UniformCrossoverEvenGenes()
        {
            var organism1 = new DummyOrganism(.25f, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var organism2 = new DummyOrganism(.75f, new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var crossover = new UniformCrossover();

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
        public void UniformCrossoverUnevenGenes()
        {
            var organism1 = new DummyOrganism(.25f, new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            var organism2 = new DummyOrganism(.75f, new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var crossover = new UniformCrossover();

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
