using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestGaussianInput
    {
        [TestMethod]
        public void GaussianInputOrdinaryCrispValueAtCenter()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.0f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueBetweenCenterAndEndOfCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.5f;

            Assert.AreEqual(0.6065306f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueEqualToEndOfCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 2.0f;
            float upperCoverage = 0.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 2.0f;

            Assert.AreEqual(0.1353352f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueBeyondEndOfCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 1.5f;
            float upperCoverage = 0.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 2.5f;

            Assert.AreEqual(0.0038659f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }

        [TestMethod]
        public void GaussianInputCeilLeftCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = true;
            bool ceilRight = false;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = -1.0f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputCeilRightCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = true;
            float coverage = 1.0f;
            float upperCoverage = 0.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 1.0f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputUpperCoverageCrispValueWithinUpperCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 2.0f;
            float upperCoverage = 1.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputUpperCoverageCrispValueBetweenUpperCoverageAndBaseCoverage()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float coverage = 2.0f;
            float upperCoverage = 1.0f;

            var gaussianInput = new GaussianInput
                (name, category, center, ceilLeft, ceilRight, coverage, upperCoverage);
            float crispValue = 1.5f;

            Assert.AreEqual(0.6065306f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }
    }
}
