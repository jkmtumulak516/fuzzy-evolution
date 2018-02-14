using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values.Generic;
using FuzzyLogicSystems.Core.Values;
using System.Collections.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestLinearInput
    {
        private FuzzySet<IInputFuzzyMember> inputFuzzySet = new TestFuzzySet(1);

        [TestMethod]
        public void LinearInputOrdinaryCrispValueAtPeak()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.0f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputOrdinaryCrispValueBetweenPeakAndEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(0.5f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputOrdinaryCrispValueAtEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 1.0f;

            Assert.AreEqual(0.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputCeilLeftCrispValueWithinCeil()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = true;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = -0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputCeilRightCrispValueWithinCeil()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = true;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputPeakWidthCrispValueWithinWidthOfPeak()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 1.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputPeakWidthCrispValueBetweenEdgeOfPeakAndEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 1.0f;

            var linearInput = new LinearInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 1.5f;

            Assert.AreEqual(0.5f, linearInput.GetMembership(crispValue));
        }

        private class TestFuzzySet : FuzzySet<IInputFuzzyMember>
        {
            public TestFuzzySet(int category) : base(category) { }

            protected override ISet<IInputFuzzyMember> InitializeMembers()
            {
                return new HashSet<IInputFuzzyMember>();
            }
        }
    }
}
