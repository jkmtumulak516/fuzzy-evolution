using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using EvolutionaryAlgorithms.Genetic.Generic;
using EvolutionaryAlgorithms.Genetic.Generic.Crossover;
using EvolutionaryAlgorithms.Genetic.Generic.Selection;
using static TestIntegration.Dummy.DummyFuzzySets;

namespace TestIntegration
{
    [TestClass]
    public class TestIntegratedEvaluationTreeRuleBaseOrganism
    {
        private readonly TestTemperature temperature = new TestTemperature(1);
        private readonly TestHeight height = new TestHeight(2);
        private readonly TestSpecial special = new TestSpecial(4);

        private readonly List<FuzzySet<IInputFuzzyMember>> inputSets;

        public TestIntegratedEvaluationTreeRuleBaseOrganism()
        {
            inputSets = new List<FuzzySet<IInputFuzzyMember>> { temperature, height };
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseWithSinglePointCrossover()
        {
            var firstRuleBase = new EvaluationTreeRuleBase(inputSets, special, Rules1());
            var secondRuleBase = new EvaluationTreeRuleBase(inputSets, special, Rules2());

            var ruleBaseFactory = new EvaluationTreeRuleBaseFactory(inputSets, special);
            var ruleCopier = new RuleCopier();

            var crossover = new SinglePointCrossover();

            try
            {
                var crossoverResult = crossover.CrossoverGenes(firstRuleBase, secondRuleBase, ruleBaseFactory, ruleCopier);

                var result1 = crossoverResult.Item1;
                var result2 = crossoverResult.Item2;

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseWithTwoPointCrossover()
        {
            var firstRuleBase = new EvaluationTreeRuleBase(inputSets, special, Rules1());
            var secondRuleBase = new EvaluationTreeRuleBase(inputSets, special, Rules2());

            var ruleBaseFactory = new EvaluationTreeRuleBaseFactory(inputSets, special);
            var ruleCopier = new RuleCopier();

            var crossover = new TwoPointCrossover();

            try
            {
                var crossoverResult = crossover.CrossoverGenes(firstRuleBase, secondRuleBase, ruleBaseFactory, ruleCopier);

                var result1 = crossoverResult.Item1;
                var result2 = crossoverResult.Item2;

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseWithUniformCrossover()
        {
            var firstRuleBase = new EvaluationTreeRuleBase(inputSets, special, Rules1());
            var secondRuleBase = new EvaluationTreeRuleBase(inputSets, special, Rules2());

            var ruleBaseFactory = new EvaluationTreeRuleBaseFactory(inputSets, special);
            var ruleCopier = new RuleCopier();

            var crossover = new UniformCrossover();

            try
            {
                var crossoverResult = crossover.CrossoverGenes(firstRuleBase, secondRuleBase, ruleBaseFactory, ruleCopier);

                var result1 = crossoverResult.Item1;
                var result2 = crossoverResult.Item2;

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseWithFitnessProportionateSelection()
        {
            var rand = new Random();
            int max = 12;

            var population = new List<EvaluationTreeRuleBase>(max);

            for (int i = 0; i < max; i++)
            {
                population.Add(new EvaluationTreeRuleBase(inputSets, special, Rules1()));
                population[i].Fitness = (float)rand.NextDouble();
            }

            var ruleBaseFactory = new EvaluationTreeRuleBaseFactory(inputSets, special);
            var ruleCopier = new RuleCopier();

            var selection = new FitnessProportionateSelection();

            try
            {
                var selectionResult = selection.SelectPairings<EvaluationTreeRuleBase, Rule>(population);
                
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseWithGeneticAlgorithm()
        {
            var rand = new Random();
            int max = 12;

            var population = new List<EvaluationTreeRuleBase>(max);

            for (int i = 0; i < max; i++)
            {
                population.Add(new EvaluationTreeRuleBase(inputSets, special, Rules1()));
                population[i].Fitness = (float)rand.NextDouble();
            }

            var ruleBaseFactory = new EvaluationTreeRuleBaseFactory(inputSets, special);
            var ruleCopier = new RuleCopier();

            var crossover = new SinglePointCrossover();
            var selection = new FitnessProportionateSelection();

            var ga = new GeneticAlgorithm<EvaluationTreeRuleBase, Rule>(selection, crossover, ruleBaseFactory, ruleCopier);

            try
            {
                var newGeneration = ga.BreedNewGeneration(population, 0.15f);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseWithStochasticUniversalSamplingSelection()
        {
            var rand = new Random();
            int max = 12;

            var population = new List<EvaluationTreeRuleBase>(max);

            for (int i = 0; i < max; i++)
            {
                population.Add(new EvaluationTreeRuleBase(inputSets, special, Rules1()));
                population[i].Fitness = (float)rand.NextDouble();
            }

            var ruleBaseFactory = new EvaluationTreeRuleBaseFactory(inputSets, special);
            var ruleCopier = new RuleCopier();

            var selection = new FitnessProportionateSelection();

            try
            {
                var selectionResult = selection.SelectPairings<EvaluationTreeRuleBase, Rule>(population);

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private List<ParentRule> Rules1()
        {
            var rules = new List<ParentRule>();
            var rb = new RuleBuilder();

            rules.Add(rb.Var(temperature.Hot).And().Var(height.Tall).Build(special.Plain));
            rules.Add(rb.Var(temperature.Hot).And().Var(height.SlightlyTall).Build(special.Unoriginal));
            rules.Add(rb.Var(temperature.Hot).And().Var(height.SlightlyShort).Build(special.Original));
            rules.Add(rb.Var(temperature.Hot).And().Var(height.Short).Build(special.Unique));

            rules.Add(rb.Var(temperature.Cold).And().Var(height.Tall).Build(special.Unique));
            rules.Add(rb.Var(temperature.Cold).And().Var(height.SlightlyTall).Build(special.Original));
            rules.Add(rb.Var(temperature.Cold).And().Var(height.SlightlyShort).Build(special.Unoriginal));
            rules.Add(rb.Var(temperature.Cold).And().Var(height.Short).Build(special.Plain));

            return rules;
        }

        private List<ParentRule> Rules2()
        {
            var rules = new List<ParentRule>();
            var rb = new RuleBuilder();

            rules.Add(rb.Var(temperature.Hot).And().Var(height.Tall).Build(special.Unique));
            rules.Add(rb.Var(temperature.Hot).And().Var(height.SlightlyTall).Build(special.Original));
            rules.Add(rb.Var(temperature.Hot).And().Var(height.SlightlyShort).Build(special.Unoriginal));
            rules.Add(rb.Var(temperature.Hot).And().Var(height.Short).Build(special.Plain));

            rules.Add(rb.Var(temperature.Cold).And().Var(height.Tall).Build(special.Plain));
            rules.Add(rb.Var(temperature.Cold).And().Var(height.SlightlyTall).Build(special.Unoriginal));
            rules.Add(rb.Var(temperature.Cold).And().Var(height.SlightlyShort).Build(special.Original));
            rules.Add(rb.Var(temperature.Cold).And().Var(height.Short).Build(special.Unique));

            return rules;
        }
    }
}
