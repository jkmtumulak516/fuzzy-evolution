using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolutionaryAlgorithms.Genetic.Generic.Selection;
using System.Collections.Generic;

namespace TestEvolutionaryAlgorithms.Genetic.Generic.Selection
{
    [TestClass]
    public class TestStochasticUniversalSamplingSelection
    {
        [TestMethod]
        public void StochasticUniversalSamplingSelectionConstruction()
        {
            try
            {
                var selection = new StochasticUniversalSamplingSelection(0.25f, 0.5f);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StochasticUniversalSamplingSelectionMinTooLow()
        {
            var selection = new StochasticUniversalSamplingSelection(-0.1f, 0.5f);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StochasticUniversalSamplingSelectionMaxTooHigh()
        {
            var selection = new StochasticUniversalSamplingSelection(0.25f, 1.1f);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StochasticUniversalSamplingSelectionMinGreaterThanMax()
        {
            var selection = new StochasticUniversalSamplingSelection(0.5f, 0.25f);
        }

        [TestMethod]
        public void StochasticUniversalSamplingSelectionSelectPairings()
        {
            var selection = new StochasticUniversalSamplingSelection(0.15f, 0.35f);

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
                var pairings = selection.SelectPairings<DummyOrganism, DummyGene>(organsims);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
