using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values.Generic;
using FuzzyLogicSystems.Core.Values;
using System.Collections.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestLinearResult
    {
        private readonly FuzzySet<IResultFuzzyMember> outputFuzzySet = new TestFuzzySet(1);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearResultDegreeIsGreaterThanOne()
        {
            string name = "test";
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, outputFuzzySet, peak, baseHalfWidth, peakHalfWidth);
            float degree = 1.0000001f;

            linearResult.GetArea(degree);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearResultDegreeIsLessThanZero()
        {
            string name = "test";
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, outputFuzzySet, peak, baseHalfWidth, peakHalfWidth);
            float degree = -0.0000001f;

            linearResult.GetArea(degree);
        }

        [TestMethod]
        public void LinearResultFullTriangle()
        {
            string name = "test";
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, outputFuzzySet, peak, baseHalfWidth, peakHalfWidth);
            float degree = 1.0f;

            Assert.AreEqual(2.5f, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultPartialTriangle()
        {
            string name = "test";
            float peak = 0.0f;
            float baseHalfWidth = 2.5f;
            float peakHalfWidth = 0.0f;

            var linearResult = new LinearResult
                (name, outputFuzzySet, peak, baseHalfWidth, peakHalfWidth);
            float degree = 0.5f;

            Assert.AreEqual(3.75, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultFullTrapezoid()
        {
            string name = "test";
            float peak = 0.0f;
            float baseHalfWidth = 5.0f;
            float peakHalfWidth = 2.5f;

            var linearResult = new LinearResult
                (name, outputFuzzySet, peak, baseHalfWidth, peakHalfWidth);
            float degree = 1.0f;

            Assert.AreEqual(7.5f, linearResult.GetArea(degree));
        }

        [TestMethod]
        public void LinearResultPartialTrapezoid()
        {
            string name = "test";
            float peak = 0.0f;
            float baseHalfWidth = 5.0f;
            float peakHalfWidth = 2.5f;

            var linearResult = new LinearResult
                (name, outputFuzzySet, peak, baseHalfWidth, peakHalfWidth);
            float degree = 0.5f;

            Assert.AreEqual(8.75f, linearResult.GetArea(degree));
        }

        private class TestFuzzySet : FuzzySet<IResultFuzzyMember>
        {
            public TestFuzzySet(int category) : base(category) { }

            protected override ISet<IResultFuzzyMember> InitializeMembers()
            {
                return new HashSet<IResultFuzzyMember>();
            }
        }
    }
}
