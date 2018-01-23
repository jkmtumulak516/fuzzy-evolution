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
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, category, peak, baseHalfWidth, peakHalfWidth);
            float degree = 1.0000001f;

            linearResult.GetArea(degree);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearResultDegreeIsLessThanZero()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, category, peak, baseHalfWidth, peakHalfWidth);
            float degree = -0.0000001f;

            linearResult.GetArea(degree);
        }

        [TestMethod]
        public void LinearResultFullTriangle()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, category, peak, baseHalfWidth, peakHalfWidth);
            float degree = 1.0f;

            Assert.AreEqual(2.5f, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultPartialTriangle()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, category, peak, baseHalfWidth, peakHalfWidth);
            float degree = 0.5f;

            Assert.AreEqual(3.75, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultFullTrapezoid()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            float baseHalfWidth = 5.0f;
            float peakHalfWidth = 2.5f;

            var linearResult = new LinearResult
                (name, category, peak, baseHalfWidth, peakHalfWidth);
            float degree = 1.0f;

            Assert.AreEqual(7.5f, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultPartialTrapezoid()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            float baseHalfWidth = 5.0f;
            float peakHalfWidth = 2.5f;

            var linearResult = new LinearResult
                (name, category, peak, baseHalfWidth, peakHalfWidth);
            float degree = 0.5f;

            Assert.AreEqual(8.75f, linearResult.GetArea(degree));
        }
    }
}
