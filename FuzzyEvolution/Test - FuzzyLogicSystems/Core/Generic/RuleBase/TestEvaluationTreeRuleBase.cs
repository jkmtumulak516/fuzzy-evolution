using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using static TestFuzzyLogicSystems.Core.DummyFuzzySets;

namespace TestFuzzyLogicSystems.Core.Generic.RuleBase
{
    [TestClass]
    public class TestEvaluationTreeRuleBase
    {
        private readonly TestTemperature temperature = new TestTemperature(1);
        private readonly TestHeight height = new TestHeight(2);
        private readonly TestSpecial special = new TestSpecial(3);

        [TestMethod]
        public void EvaluationTreeRuleBaseConstructor()
        {
            var inputSets = new List<FuzzySet<IInputFuzzyMember>>() { temperature, height };
            var rules = CreateRules();

            try
            {
                var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);
            }
            catch (Exception ex)
            {
                Assert.Fail("RuleBase construction failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseEvaluateSingleCombinations1()
        {
            var inputSets = new List<FuzzySet<IInputFuzzyMember>>() { temperature, height };
            var rules = CreateRules();

            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);

            var input = new Dictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>
            {
                { temperature.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.7f, temperature.Hot)} },
                { height.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.9f, height.Tall)} }
            };

            try
            {
                var results = ruleBase.Evaluate(input);

                Assert.AreEqual(1, results.Count, 0, "Number of results does not meet expected amount.");
                Assert.AreEqual(0.7f, results[0].Degree, 0, "FuzzyValue degree does not meet expected amount.");
                Assert.AreEqual(special.Plain.Name, results[0].FuzzyMember.Name, "FuzzyValue does not match expected member.");
            }
            catch (Exception ex)
            {
                Assert.Fail("RuleBase failed to evaluate input: " + ex.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseEvaluateSingleCombinations2()
        {
            var inputSets = new List<FuzzySet<IInputFuzzyMember>>() { temperature, height };
            var rules = CreateRules();

            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);

            var input = new Dictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>
            {
                { temperature.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.5f, temperature.Cool)} },
                { height.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.3f, height.Tall)} }
            };

            try
            {
                var results = ruleBase.Evaluate(input);

                Assert.AreEqual(1, results.Count, 0, "Number of results does not meet expected amount.");
                Assert.AreEqual(0.3f, results[0].Degree, 0, "FuzzyValue degree does not meet expected amount.");
                Assert.AreEqual(special.Unique.Name, results[0].FuzzyMember.Name, "FuzzyValue does not match expected member.");
            }
            catch (Exception ex)
            {
                Assert.Fail("RuleBase failed to evaluate input: " + ex.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseEvaluateSingleCombinations3()
        {
            var inputSets = new List<FuzzySet<IInputFuzzyMember>>() { temperature, height };
            var rules = CreateRules();

            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);

            var input = new Dictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>
            {
                { temperature.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.4f, temperature.Cold)} },
                { height.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.4f, height.SlightlyTall)} }
            };

            try
            {
                var results = ruleBase.Evaluate(input);

                Assert.AreEqual(1, results.Count, 0, "Number of results does not meet expected amount.");
                Assert.AreEqual(0.4f, results[0].Degree, 0, "FuzzyValue degree does not meet expected amount.");
                Assert.AreEqual(special.Unoriginal.Name, results[0].FuzzyMember.Name, "FuzzyValue does not match expected member.");
            }
            catch (Exception ex)
            {
                Assert.Fail("RuleBase failed to evaluate input: " + ex.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseEvaluateSingleCombinations4()
        {
            var inputSets = new List<FuzzySet<IInputFuzzyMember>>() { temperature, height };
            var rules = CreateRules();

            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);

            var input = new Dictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>
            {
                { temperature.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.7f, temperature.Warm)} },
                { height.Category, new List<FuzzyValue<IInputFuzzyMember>> { new FuzzyValue<IInputFuzzyMember>(0.3f, height.SlightlyShort)} }
            };

            try
            {
                var results = ruleBase.Evaluate(input);

                Assert.AreEqual(1, results.Count, 0, "Number of results does not meet expected amount.");
                Assert.AreEqual(0.3f, results[0].Degree, 0, "FuzzyValue degree does not meet expected amount.");
                Assert.AreEqual(special.Original.Name, results[0].FuzzyMember.Name, "FuzzyValue does not match expected member.");
            }
            catch (Exception ex)
            {
                Assert.Fail("RuleBase failed to evaluate input: " + ex.Message);
            }
        }

        [TestMethod]
        public void EvaluationTreeRuleBaseEvaluateDoubleCombinations()
        {
            var inputSets = new List<FuzzySet<IInputFuzzyMember>>() { temperature, height };
            var rules = CreateRules();

            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);

            var input = new Dictionary<int, IList<FuzzyValue<IInputFuzzyMember>>>
            {
                { temperature.Category, new List<FuzzyValue<IInputFuzzyMember>>
                    { new FuzzyValue<IInputFuzzyMember>(0.4f, temperature.Cold),
                    new FuzzyValue<IInputFuzzyMember>(0.4f, temperature.Warm) }
                },
                { height.Category, new List<FuzzyValue<IInputFuzzyMember>>
                    { new FuzzyValue<IInputFuzzyMember>(0.4f, height.SlightlyTall),
                    new FuzzyValue<IInputFuzzyMember>(0.4f, height.Short) }
                }
            };

            try
            {
                var results = ruleBase.Evaluate(input);

                Assert.AreEqual(4, results.Count, 0, "Number of results does not meet expected amount.");
            }
            catch (Exception ex)
            {
                Assert.Fail("RuleBase failed to evaluate input: " + ex.Message);
            }
        }

        private List<ParentRule> CreateRules()
        {
            var listOfRules = new List<ParentRule>();
            var rb = new RuleBuilder();

            /* ---------- HOT ---------- */

            // 1: Hot AND Tall => Plain
            listOfRules.Add(rb.Var(temperature.Hot).And().Var(height.Tall).Build(special.Plain));
            rb.Reset();
            // 2: Hot AND Slightly Tall => Plain
            listOfRules.Add(rb.Var(temperature.Hot).And().Var(height.SlightlyTall).Build(special.Plain));
            rb.Reset();
            // 3: Hot AND Slightly Short => Unoriginal
            listOfRules.Add(rb.Var(temperature.Hot).And().Var(height.SlightlyShort).Build(special.Unoriginal));
            rb.Reset();
            // 4: Hot AND Short => Original
            listOfRules.Add(rb.Var(temperature.Hot).And().Var(height.Short).Build(special.Original));
            rb.Reset();

            /* ---------- WARM ---------- */

            // 5: Warm AND Tall => Unoriginal
            listOfRules.Add(rb.Var(temperature.Warm).And().Var(height.Tall).Build(special.Unoriginal));
            rb.Reset();
            // 6: Warm AND Slightly Tall => Original
            listOfRules.Add(rb.Var(temperature.Warm).And().Var(height.SlightlyTall).Build(special.Original));
            rb.Reset();
            // 7: Warm AND Slightly Short => Original
            listOfRules.Add(rb.Var(temperature.Warm).And().Var(height.SlightlyShort).Build(special.Original));
            rb.Reset();
            // 8: Warm AND Short => Unique
            listOfRules.Add(rb.Var(temperature.Warm).And().Var(height.Short).Build(special.Unique));
            rb.Reset();

            /* ---------- COOL ---------- */

            // 9: Cool AND Tall => Unique
            listOfRules.Add(rb.Var(temperature.Cool).And().Var(height.Tall).Build(special.Unique));
            rb.Reset();
            // 10: Cool AND Slightly Tall => Original
            listOfRules.Add(rb.Var(temperature.Cool).And().Var(height.SlightlyTall).Build(special.Original));
            rb.Reset();
            // 11: Cool AND Slightly Short => Original
            listOfRules.Add(rb.Var(temperature.Cool).And().Var(height.SlightlyShort).Build(special.Original));
            rb.Reset();
            // 12: Cool AND Short => Unoriginal
            listOfRules.Add(rb.Var(temperature.Cool).And().Var(height.Short).Build(special.Unoriginal));
            rb.Reset();

            /* ---------- COLD ---------- */

            // 13: Cold AND Tall => Original
            listOfRules.Add(rb.Var(temperature.Cold).And().Var(height.Tall).Build(special.Original));
            rb.Reset();
            // 14: Cold AND Slightly Tall => Unoriginal
            listOfRules.Add(rb.Var(temperature.Cold).And().Var(height.SlightlyTall).Build(special.Unoriginal));
            rb.Reset();
            // 15: Cold AND Slightly Short => Plain
            listOfRules.Add(rb.Var(temperature.Cold).And().Var(height.SlightlyShort).Build(special.Plain));
            rb.Reset();
            // 16: Cold AND Short => Plain
            listOfRules.Add(rb.Var(temperature.Cold).And().Var(height.Short).Build(special.Plain));
            rb.Reset();

            return listOfRules;
        }
    }
}
