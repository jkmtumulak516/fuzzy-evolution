using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolutionaryAlgorithms.Genetic;
using EvolutionaryAlgorithms.Genetic.Generic;
using EvolutionaryAlgorithms.Genetic.Generic.Crossover;
using EvolutionaryAlgorithms.Genetic.Generic.Selection;
using System.Collections.Generic;

namespace TestEvolutionaryAlgorithms.Genetic.Generic
{
    [TestClass]
    public class TestGeneticAlgorithm
    {
        [TestMethod]
        public void GeneticAlgorithmConstruction()
        {
            var crossover = new SinglePointCrossover();
            var selection = new FitnessProportionateSelection();
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            try
            {
                var ga = new GeneticAlgorithm<DummyOrganism, DummyGene>(selection, crossover, organismFactory, geneCopier);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GeneticAlgorithmCrossoverIsNull()
        {
            ICrossoverMethod crossover = null;
            var selection = new FitnessProportionateSelection();
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var ga = new GeneticAlgorithm<DummyOrganism, DummyGene>(selection, crossover, organismFactory, geneCopier);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GeneticAlgorithmSelectionIsNull()
        {
            var crossover = new SinglePointCrossover();
            ISelectionMethod selection = null;
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var ga = new GeneticAlgorithm<DummyOrganism, DummyGene>(selection, crossover, organismFactory, geneCopier);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GeneticAlgorithmOrganismFactoryIsNull()
        {
            var crossover = new SinglePointCrossover();
            var selection = new FitnessProportionateSelection();
            IOrganismFactory<DummyOrganism, DummyGene> organismFactory = null;
            var geneCopier = new DummyGeneCopier();

            var ga = new GeneticAlgorithm<DummyOrganism, DummyGene>(selection, crossover, organismFactory, geneCopier);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GeneticAlgorithmGeneCopierIsNull()
        {
            var crossover = new SinglePointCrossover();
            var selection = new FitnessProportionateSelection();
            var  organismFactory = new DummyOrganismFactory(); ;
            IGeneCopier<DummyGene> geneCopier = null;

            var ga = new GeneticAlgorithm<DummyOrganism, DummyGene>(selection, crossover, organismFactory, geneCopier);
        }

        [TestMethod]
        public void GeneticAlgorithmBreedNewGeneration()
        {
            var crossover = new SinglePointCrossover();
            var selection = new FitnessProportionateSelection();
            var organismFactory = new DummyOrganismFactory();
            var geneCopier = new DummyGeneCopier();

            var ga = new GeneticAlgorithm<DummyOrganism, DummyGene>(selection, crossover, organismFactory, geneCopier);

            var organsims = new List<DummyOrganism>
            {
                new DummyOrganism(.15f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.25f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),

                new DummyOrganism(.35f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.45f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),

                new DummyOrganism(.55f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.65f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),

                new DummyOrganism(.10f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.20f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),

                new DummyOrganism(.30f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.40f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),

                new DummyOrganism(.50f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.60f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),

                new DummyOrganism(.70f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
                new DummyOrganism(.80f, new List<int> { 1, 2, 3, 4, 5, 6, 7 }),
            };

            try
            {
                var newPopulation = ga.BreedNewGeneration(organsims, 0.09f);    
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
