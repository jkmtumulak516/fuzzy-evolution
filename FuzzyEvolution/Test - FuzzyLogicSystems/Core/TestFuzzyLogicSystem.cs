using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TestFuzzyLogicSystems.Core.DummyFuzzySets;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;

namespace TestFuzzyLogicSystems.Core
{
    [TestClass]
    public class TestFuzzyLogicSystem
    {
        private readonly TestTemperature temperature = new TestTemperature(1);
        private readonly TestHeight height = new TestHeight(2);
        //private readonly TestWeight weight = new TestWeight(3);
        private readonly TestSpecial special = new TestSpecial(4);

        private readonly List<FuzzySet<IInputFuzzyMember>> inputSets;

        public TestFuzzyLogicSystem()
        {
            inputSets = new List<FuzzySet<IInputFuzzyMember>> { temperature, height };
        }

        [TestMethod]
        public void FuzzyLogicSystemConstructor()
        {
            var rules = CreateRules();
            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);
            try
            {
                var fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);
            }
            catch (Exception e)
            {
                Assert.Fail("FuzzyLogicSystem construction failed: " + e.StackTrace);
            }
        }

        [TestMethod]
        public void FuzzyLogicSystemSimpleInput1()
        {
            var rules = CreateRules();
            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);
            var fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);

            var dictInput = new Dictionary<int, float>
            {
                { temperature.Category, 27.5f },
                { height.Category, 180f }
            };

            float output = fls.Evaluate(dictInput);

            Assert.AreEqual(85f, output, 0f, "Incorrect output.");
        }

        [TestMethod]
        public void FuzzyLogicSystemSimpleInput2()
        {
            var rules = CreateRules();
            var ruleBase = new EvaluationTreeRuleBase(inputSets, special, rules);
            var fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);

            var dictInput = new Dictionary<int, float>
            {
                { temperature.Category, 12.5f },
                { height.Category, 160f }
            };

            float output = fls.Evaluate(dictInput);

            Assert.AreEqual(20f, output, 0f, "Incorrect output.");
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
