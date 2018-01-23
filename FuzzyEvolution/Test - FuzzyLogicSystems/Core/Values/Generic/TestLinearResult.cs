using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestLinearResult
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearResultDegreeIsGreaterThanOne()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            float coverage = 2.5f;
            float upperCoverage = 0.0f;

            var linearResult = new LinearResult
                (name, category, center, coverage, upperCoverage);
            float degree = 1.0000001f;

            linearResult.GetArea(degree);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearResultDegreeIsLessThanZero()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            float coverage = 2.5f;
            float upperCoverage = 0.0f;

            var linearResult = new LinearResult
                (name, category, center, coverage, upperCoverage);
            float degree = -0.0000001f;

            linearResult.GetArea(degree);
        }

        [TestMethod]
        public void LinearResultFullTriangle()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            float coverage = 2.5f;
            float upperCoverage = 0.0f;

            var linearResult = new LinearResult
                (name, category, center, coverage, upperCoverage);
            float degree = 1.0f;

            Assert.AreEqual(2.5f, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultPartialTriangle()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            float coverage = 2.5f;
            float upperCoverage = 0.0f;

            var linearResult = new LinearResult
                (name, category, center, coverage, upperCoverage);
            float degree = 0.5f;

            Assert.AreEqual(3.75, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultFullTrapezoid()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            float coverage = 5.0f;
            float upperCoverage = 2.5f;

            var linearResult = new LinearResult
                (name, category, center, coverage, upperCoverage);
            float degree = 1.0f;

            Assert.AreEqual(7.5f, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultPartialTrapezoid()
        {
            string name = "test";
            int category = 1;
            float center = 0.0f;
            float coverage = 5.0f;
            float upperCoverage = 2.5f;

            var linearResult = new LinearResult
                (name, category, center, coverage, upperCoverage);
            float degree = 0.5f;

            Assert.AreEqual(8.75f, linearResult.GetArea(degree));
        }
    }
}
