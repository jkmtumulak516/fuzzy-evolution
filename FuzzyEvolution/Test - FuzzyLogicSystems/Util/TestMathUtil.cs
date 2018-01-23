using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuzzyLogicSystems.Util;

namespace TestFuzzyLogicSystems.Util
{
    [TestClass]
    public class TestMathUtil
    {
        [TestMethod]
        public void GaussianDistanceCenterAndValueAreEqual()
        {
            float height = 1.0f;
            float peak = 0.0f;
            float baseWidth = 2.0f;
            float value = 0.0f;

            Assert.AreEqual(1.0f, MathUtil.GaussianDistance(height, peak, baseWidth, value));
        }

        [TestMethod]
        public void GaussianDistanceValueBetweenCenterAndEndOfWidth()
        {
            float height = 1.0f;
            float peak = 0.0f;
            float baseWidth = 2.0f;
            float value = 0.5f;

            Assert.AreEqual(0.6065306f, MathUtil.GaussianDistance(height, peak, baseWidth, value), 0.0000001f);
        }

        [TestMethod]
        public void GaussianDistanceValueEqualToEndOfWidth()
        {
            float height = 2.0f;
            float peak = 0.0f;
            float baseWidth = 4.0f;
            float value = 2.0f;

            Assert.AreEqual(0.2706705f, MathUtil.GaussianDistance(height, peak, baseWidth, value), 0.0000001f);
        }

        [TestMethod]
        public void GaussianDistanceValueIsBeyondWidth()
        {
            float height = 1f;
            float peak = 0.0f;
            float baseWidth = 3.0f;
            float value = 2.5f;

            Assert.AreEqual(0.0038659f, MathUtil.GaussianDistance(height, peak, baseWidth, value), 0.0000001f);
        }

        [TestMethod]
        public void LinearDistanceCenterAndValueAreEqual()
        {
            float peak = 0.0f;
            float value = 0.0f;

            Assert.AreEqual(1.0f, MathUtil.LinearDistance(peak, value));
        }

        [TestMethod]
        public void LinearDistanceValueWithinBounds()
        {
            float peak = 2.0f;
            float value = 0.0f;
            float bounds = 4.0f;

            Assert.AreEqual(0.5f, MathUtil.LinearDistance(peak, value, bounds));
        }

        [TestMethod]
        public void LinearDistanceValueWithoutBounds()
        {
            float peak = 2.0f;
            float value = 6.1f;
            float bounds = 4.0f;

            Assert.AreEqual(0.0f, MathUtil.LinearDistance(peak, value, bounds));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearDistanceBoundsIsZero()
        {
            float peak = 0.0f;
            float value = 0.0f;
            float bounds = 0.0f;

            MathUtil.LinearDistance(peak, value, bounds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearDistanceBoundsIsNegative()
        {
            float peak = 0.0f;
            float value = 0.0f;
            float bounds = -1.0f;

            MathUtil.LinearDistance(peak, value, bounds);
        }

        [TestMethod]
        public void ParallelTrapezoidalAreaUprightTriangle()
        {   
            float height = 3.0f;
            float upperWidth = 0.0f;
            float lowerWidth = 5.0f;

            Assert.AreEqual(7.5f, MathUtil.ParallelTrapezoidalArea(height, upperWidth, lowerWidth));
        }

        [TestMethod]
        public void ParallelTrapezoidalAreaUpsideDownTriangle()
        {
            float height = 3.0f;
            float upperWidth = 5.0f;
            float lowerWidth = 0.0f;

            Assert.AreEqual(7.5f, MathUtil.ParallelTrapezoidalArea(height, upperWidth, lowerWidth));
        }

        [TestMethod]
        public void ParallelTrapezoidalAreaUprightTrapezoid()
        {
            float height = 5.0f;
            float upperWidth = 10.0f;
            float lowerWidth = 5.0f;

            Assert.AreEqual(37.5f, MathUtil.ParallelTrapezoidalArea(height, upperWidth, lowerWidth));
        }

        [TestMethod]
        public void ParallelTrapezoidalAreaUpsideDownTrapezoidTest()
        {
            float height = 5.0f;
            float upperWidth = 5.0f;
            float lowerWidth = 10.0f;

            Assert.AreEqual(37.5f, MathUtil.ParallelTrapezoidalArea(height, upperWidth, lowerWidth));
        }

        [TestMethod]
        public void ParallelTrapezoidalAreaZeroHeight()
        {
            float height = 0.0f;
            float upperWidth = 1.0f;
            float lowerWidth = 1.0f;

            Assert.AreEqual(0.0f, MathUtil.ParallelTrapezoidalArea(height, upperWidth, lowerWidth));
        }

        [TestMethod]
        public void ParallelTrapezoidalAreaZeroWidth()
        {
            float height = 1.0f;
            float upperWidth = 0.0f;
            float lowerWidth = 0.0f;

            Assert.AreEqual(0.0f, MathUtil.ParallelTrapezoidalArea(height, upperWidth, lowerWidth));
        }
    }
}
