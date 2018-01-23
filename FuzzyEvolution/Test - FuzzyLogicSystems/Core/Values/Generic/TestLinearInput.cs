using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestLinearInput
    {
        [TestMethod]
        public void LinearInputOrdinaryCrispValueAtPeak()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.0f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputOrdinaryCrispValueBetweenPeakAndEdgeOfBase()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(0.5f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputOrdinaryCrispValueAtEdgeOfBase()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 1.0f;

            Assert.AreEqual(0.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputCeilLeftCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = true;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = -0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputCeilRightCrispValueWithinCeil()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = true;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputPeakWidthCrispValueWithinWidthOfPeak()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 1.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, linearInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void LinearInputPeakWidthCrispValueBetweenEdgeOfPeakAndEdgeOfBase()
        {
            string name = "test";
            int category = 1;
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 1.0f;

            var linearInput = new LinearInput
                (name, category, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 1.5f;

            Assert.AreEqual(0.5f, linearInput.GetMembership(crispValue));
        }
    }
}
