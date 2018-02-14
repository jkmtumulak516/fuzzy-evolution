using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System.Collections.Generic;

namespace TestFuzzyLogicSystems.Core.Values.Generic
{
    [TestClass]
    public class TestGaussianInput
    {
        private FuzzySet<IInputFuzzyMember> inputFuzzySet = new TestFuzzySet(1);

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueAtPeak()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.0f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueBetweenPeakAndEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(0.6065306f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueEqualToEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 0.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 2.0f;

            Assert.AreEqual(0.1353352f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }

        [TestMethod]
        public void GaussianInputOrdinaryCrispValueBeyondEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 1.5f;
            float peakHalfWidth = 0.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 2.5f;

            Assert.AreEqual(0.0038659f, gaussianInput.GetMembership(crispValue), 0.0000001f);
        }

        [TestMethod]
        public void GaussianInputCeilLeftCrispValueWithinCeil()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = true;
            bool ceilRight = false;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = -1.0f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputCeilRightCrispValueWithinCeil()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = true;
            float baseHalfWidth = 1.0f;
            float peakHalfWidth = 0.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 1.0f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputPeakWidthCrispValueWithinWidthOfPeak()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 1.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 0.5f;

            Assert.AreEqual(1.0f, gaussianInput.GetMembership(crispValue));
        }

        [TestMethod]
        public void GaussianInputPeakWidthCrispValueBetweenEdgeOfPeakAndEdgeOfBase()
        {
            string name = "test";
            float peak = 0.0f;
            bool ceilLeft = false;
            bool ceilRight = false;
            float baseHalfWidth = 2.0f;
            float peakHalfWidth = 1.0f;

            var gaussianInput = new GaussianInput
                (name, inputFuzzySet, peak, ceilLeft, ceilRight, baseHalfWidth, peakHalfWidth);
            float crispValue = 1.5f;

            Assert.AreEqual(0.6065306f, gaussianInput.GetMembership(crispValue), 0.0000001f);
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
