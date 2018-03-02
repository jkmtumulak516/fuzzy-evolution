using EvolutionaryAlgorithms.Genetic.Generic.Selection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestEvolutionaryAlgorithms.Genetic.Generic.Selection
{
    [TestClass]
    public class TestFitnessProportionateSelection
    {
        [TestMethod]
        public void FitnessProportionateSelectionConstruction()
        {
            try
            {
                var selection = new FitnessProportionateSelection();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void FitnessProportionateSelectionSelectPairings()
        {
            var selection = new FitnessProportionateSelection();

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
                var pairings = selection.SelectPairings<DummyOrganism, DummyGene> (organsims);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
