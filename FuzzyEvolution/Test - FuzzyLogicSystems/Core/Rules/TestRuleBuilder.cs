using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Rules.Exception;
using static TestFuzzyLogicSystems.Core.Rules.DummyFuzzySets;

namespace TestFuzzyLogicSystems.Core.Rules
{
    [TestClass]
    public class TestRuleBuilder
    {
        private readonly TestTemperature temperature = new TestTemperature(1);
        private readonly TestHeight height = new TestHeight(2);
        private readonly TestSpecial special = new TestSpecial(3);

        [TestMethod]
        public void RuleBuilderBasicANDRule()
        {
            var rb = new RuleBuilder();

            try
            {
                var rule
                    = rb
                    .Var(temperature.Hot)
                    .And()
                    .Var(height.Tall)
                    .Build(special.Unique);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception: " + ex.Message);
            }
        }

        [TestMethod]
        public void RuleBuilderBasicORRule()
        {
            var rb = new RuleBuilder();

            try
            {
                var rule
                    = rb
                    .Var(temperature.Hot)
                    .Or()
                    .Var(height.Tall)
                    .Build(special.Unique);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception: " + ex.Message);
            }
        }

        [TestMethod]
        public void RuleBuilderCompoundRule()
        {
            var rb = new RuleBuilder();

            try
            {
                var rule
                    = rb
                    // hot AND tall
                    .Var(temperature.Hot).And().Var(height.Tall)
                    .Or() // OR
                          // cold AND short
                    .Var(temperature.Cold).And().Var(height.Short)
                    .Build(special.Unique);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception: " + ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(RuleSyntaxException))]
        public void RuleBuilderStartsWithAnOperator()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .And()
                .Var(temperature.Hot)
                .Or()
                .Var(height.Tall)
                .Build(special.Unique);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleSyntaxException))]
        public void RuleBuilderRuleEndsWithOperator()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .Or()
                .Var(temperature.Cold)
                .And()
                .Build(special.Unique);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleSyntaxException))]
        public void RuleBuilderOperandAfterAnotherOperand()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot)
                .Var(height.Tall)
                .Or()
                .Var(temperature.Cold)
                .Var(height.Short)
                .Build(special.Unique);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleSyntaxException))]
        public void RuleBuilderOperatorAfterAnotherOperator()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .Var(temperature.Hot).And().Var(height.Tall)
                .Or()
                .And()
                .Var(temperature.Cold).And()
                .Build(special.Unique);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleSyntaxException))]
        public void RuleBuilderOnlyOperands()
        {
            var rb = new RuleBuilder();


            var rule
                = rb
                .Var(temperature.Hot)
                .Var(height.Tall)
                .Var(temperature.Cold)
                .Var(height.Short)
                .Build(special.Unique);
        }

        [TestMethod]
        [ExpectedException(typeof(RuleSyntaxException))]
        public void RuleBuilderOnlyOperators()
        {
            var rb = new RuleBuilder();

            var rule
                = rb
                .And()
                .Or()
                .And()
                .Or()
                .Build(special.Unique);
        }
    }
}
