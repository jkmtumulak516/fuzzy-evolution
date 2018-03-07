using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core;
using FuzzyLogicSystems.Core.Values;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Generic.RuleBase;
using FuzzyLogicSystems.Core.Generic;
using FuzzyLogicSystems.Core.Generic.Fuzzifier;
using FuzzyLogicSystems.Core.Generic.Defuzzifier;

namespace TestRobotSoccer.GameState
{
    [TestClass]
    public class TestGameState
    {
        private readonly Orientation orientation = new Orientation(1);
        private readonly DistanceDifference distanceDifference = new DistanceDifference(2);
        private readonly DistanceGoal distanceGoal = new DistanceGoal(3);
        private readonly StateValue stateValue = new StateValue(4);

        private IFuzzyRuleBase ruleBase;
        private IFuzzyLogicSystem fls;

        public TestGameState()
        {
            var listInput = new List<FuzzySet<IInputFuzzyMember>>() { orientation, distanceDifference, distanceGoal };
            var rules = CreateRules();

            ruleBase = new EvaluationTreeRuleBase(listInput, stateValue, rules);
            fls = new FuzzyLogicSystem(new Fuzzifier(), new CenterOfSumsDefuzzifier(), ruleBase);
        }

        [TestMethod]
        public void GameStateValues1()
        {
            float o = 41.94782f, dd = 3.262646f, gd = 77.57933f;

            var input = new Dictionary<int, float>
            {
                { orientation.Category, o },
                { distanceDifference.Category, dd },
                { distanceGoal.Category, gd }
            };

            try
            {
                fls.Evaluate(input);
            }

            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }

        [TestMethod]
        public void GameStateValues2()
        {
            float o = 72.86312f, dd = -2.779995f, gd = 89.11304f;

            var input = new Dictionary<int, float>
            {
                { orientation.Category, o },
                { distanceDifference.Category, dd },
                { distanceGoal.Category, gd }
            };

            try
            {
                fls.Evaluate(input);
            }

            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }

        [TestMethod]
        public void GameStateValues3()
        {
            float o = 37.23019f, dd = 9.886787f, gd = 68.00914f;

            var input = new Dictionary<int, float>
            {
                { orientation.Category, o },
                { distanceDifference.Category, dd },
                { distanceGoal.Category, gd }
            };

            try
            {
                fls.Evaluate(input);
            }

            catch (Exception e)
            {
                Assert.Fail(e.StackTrace);
            }
        }

        public List<ParentRule> CreateRules()
        {
            var listOfRules = new List<ParentRule>();
            var builder = new RuleBuilder();

            //==================================== VERY GOOD ==========================================

            // -----------------------------LEADING WIDELY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.Medium).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.VeryFar).Build(stateValue.DefenseOffense));

            // -----------------------------LEADING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.Medium).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.VeryFar).Build(stateValue.DefenseOffense));

            // -----------------------------SAME --------------------------------------------
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.Same).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.Same).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.Same).And().Var(distanceGoal.Medium).Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.Same).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.Same).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));

            // -----------------------------LAGGING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.VeryNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.Medium).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));

            // -----------------------------LAGGING WIDELY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.Medium).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.VeryGood).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));
            

            //==================================== GOOD ==========================================

            // -----------------------------LEADING WIDELY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.Medium).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.VeryFar).Build(stateValue.DefenseOffense));

            // -----------------------------LEADING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.Medium).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.VeryFar).Build(stateValue.DefenseOffense));

            // -----------------------------SAME --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.Same).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.Same).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.Same).And().Var(distanceGoal.Medium).Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.Same).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.Same).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));

            // -----------------------------LAGGING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.VeryNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.Medium).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));

            // -----------------------------LAGGING WIDELY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.Medium).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.Good).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));
            

            //==================================== BAD ==========================================

            // -----------------------------LEADING WIDELY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.Medium).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingWidely).And().Var(distanceGoal.VeryFar).Build(stateValue.DefenseOffense));

            // -----------------------------LEADING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.VeryNear).Build(stateValue.MoreOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.Medium).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LeadingSlightly).And().Var(distanceGoal.VeryFar).Build(stateValue.DefenseOffense));

            // -----------------------------SAME --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.Same).And().Var(distanceGoal.VeryNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.Same).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.Same).And().Var(distanceGoal.Medium).Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.Same).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.Same).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));

            // -----------------------------LAGGING SLIGHTLY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.VeryNear).Build(stateValue.LightOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.DefenseOffense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.Medium).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingSlightly).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));

            // -----------------------------LAGGING WIDELY --------------------------------------------
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.VeryNear).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.ModeratelyNear).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.Medium).Build(stateValue.LightDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.ModeratelyFar).Build(stateValue.MoreDefense));
            listOfRules.Add(builder.Var(orientation.Bad).And().Var(distanceDifference.LaggingWidely).And().Var(distanceGoal.VeryFar).Build(stateValue.MoreDefense));
            

            return listOfRules;
        }
    }
}
