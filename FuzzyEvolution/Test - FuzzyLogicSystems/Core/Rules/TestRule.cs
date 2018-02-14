using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Rules;
using static TestFuzzyLogicSystems.Core.DummyFuzzySets;
using FuzzyLogicSystems.Core.Values;

namespace TestFuzzyLogicSystems.Core.Rules
{
    [TestClass]
    public class TestRule
    {
        private readonly TestTemperature temperature = new TestTemperature(1);
        private readonly TestHeight height = new TestHeight(2);
        private readonly TestSpecial special = new TestSpecial(3);

        [TestMethod]
        public void RulesEvaluateTRUEWithBasicANDRule()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Tall)}
            };

            Assert.IsTrue(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateFALSEWithBasicANDRule()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Short)}
            };

            Assert.IsFalse(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateTRUEWithBasicORRule()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .Or()
                .Var(height.Tall)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Short)}
            };

            Assert.IsTrue(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateFALSEWithBasicOrRule()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .Or()
                .Var(height.Tall)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Cold)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Short)}
            };

            Assert.IsFalse(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateTRUEWithCompoundRule1()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Tall)}
            };

            Assert.IsTrue(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateTRUEWithCompoundRule2()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Cold)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Short)}
            };

            Assert.IsTrue(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateTRUEWithCompoundRule3()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.SlightlyShort)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Warm)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.SlightlyShort)}
            };

            Assert.IsTrue(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateTRUEWithCompoundRule4()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.SlightlyShort)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Warm)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Warm)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Short)}
            };

            Assert.IsTrue(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateFALSEWithCompoundRule1()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Short)}
            };

            Assert.IsFalse(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateFALSEWithCompoundRule2()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Cold)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Tall)}
            };

            Assert.IsFalse(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateFALSEWithCompoundRule3()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.SlightlyShort)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Warm)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Warm)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.SlightlyShort)}
            };

            Assert.IsFalse(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesEvaluateFALSEWithCompoundRule4()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.SlightlyShort)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Warm)
                .And()
                .Var(height.Short)
                .Build(special.Unique);

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Tall)}
            };

            Assert.IsFalse(rule.Evaluate(input));
        }

        [TestMethod]
        public void RulesGetSubRules()
        {
            var rb1 = new RuleBuilder();

            var rule
                = rb1
                .Var(temperature.Hot)
                .And()
                .Var(height.SlightlyShort)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Var(height.Tall)
                .Or()
                .Var(temperature.Warm)
                .And()
                .Var(height.Short)
                .Build(special.Unique);
            
            try
            {
                var subRules = rule.SubRules();
            }
            catch (Exception ex)
            {
                Assert.Fail("Getting SubRules failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void RulesSubRulesEvaluateTRUE()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .And()
                .Var(height.Tall)
                .Build(special.Unique);

            var subRule = rule.SubRules()[0];

            var input = new Dictionary<int, FuzzyValue<IInputFuzzyMember>>
            {
                { temperature.Category, new FuzzyValue<IInputFuzzyMember>(.7f, temperature.Hot)},
                { height.Category, new FuzzyValue<IInputFuzzyMember>(.7f, height.Tall)}
            };

            Assert.IsTrue(subRule.Evaluate(input));
        }
    }
}
