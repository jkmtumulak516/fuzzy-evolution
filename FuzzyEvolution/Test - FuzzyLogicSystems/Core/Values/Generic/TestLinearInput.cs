using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestLinearInput
    {
        [TestMethod]
        public void LinearInputOrdinaryCrispValueEqualToCenter()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.0f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputOrdinaryCrispValueBetweenCenterAndEndOfCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.5f;

            Assert.AreEqual(0.5f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputOrdinaryCrispValueEqualToEndOfCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 1.0f;

            Assert.AreEqual(0.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputCeilLeftCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = true;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = -0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputCeilRightCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = true;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputUpperCoverageCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 2.0f;
            float upperCoverage = 1.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputUpperCoverageCrispValueBetweenUpperCoverageAndBaseCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 2.0f;
            float upperCoverage = 1.0f;

            var linearInput = new LinearInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 1.5f;

            Assert.AreEqual(0.5f, linearInput.GetMembership(crispValue));
        }
    }
}
