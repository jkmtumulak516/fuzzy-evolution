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
            float center = 0.0f;
            float width = 2.0f;
            float value = 0.0f;

            Assert.AreEqual(1.0f, MathUtil.GaussianDistance(height, center, width, value));
        }

        [TestMethod]
        public void TestGaussianDistance2()
        {
            float height = 1.0f;
            float center = 0.0f;
            float width = 4.0f;
            float value = 1.0f;

            Assert.AreEqual(0.9692332f, MathUtil.GaussianDistance(height, center, width, value), 0.0000001f);
        }

        [TestMethod]
        public void TestGaussianDistance3()
        {
            float height = 2.0f;
            float center = 5.0f;
            float width = 5.0f;
            float value = 8.0f;

            Assert.AreEqual(1.6705404f, MathUtil.GaussianDistance(height, center, width, value), 0.0000001f);
        }

        [TestMethod]
        public void TestGaussianDistance4()
        {
            float height = 1.5f;
            float center = -3.0f;
            float width = 2.0f;
            float value = 0.0f;

            Assert.AreEqual(0.4869787f, MathUtil.GaussianDistance(height, center, width, value), 0.0000001f);
        }

        [TestMethod]
        public void LinearDistanceCenterAndValueAreEqual()
        {
            float center = 0.0f;
            float value = 0.0f;

            Assert.AreEqual(1.0f, MathUtil.LinearDistance(center, value));
        }

        [TestMethod]
        public void LinearDistanceValueWithinBounds()
        {
            float center = 2.0f;
            float value = 0.0f;
            float bounds = 4.0f;

            Assert.AreEqual(0.5f, MathUtil.LinearDistance(center, value, bounds));
        }

        [TestMethod]
        public void LinearDistanceValueWithoutBounds()
        {
            float center = 2.0f;
            float value = 6.1f;
            float bounds = 4.0f;

            Assert.AreEqual(0.0f, MathUtil.LinearDistance(center, value, bounds));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearDistanceBoundsIsZero()
        {
            float center = 0.0f;
            float value = 0.0f;
            float bounds = 0.0f;

            MathUtil.LinearDistance(center, value, bounds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LinearDistanceBoundsIsNegative()
        {
            float center = 0.0f;
            float value = 0.0f;
            float bounds = -1.0f;

            MathUtil.LinearDistance(center, value, bounds);
        }

        [TestMethod]
        public void TestParallelTrapezoidalArea1()
        {
        }

        [TestMethod]
        public void TestParallelTrapezoidalArea2()
        {
        }

        [TestMethod]
        public void TestParallelTrapezoidalArea3()
        {
        }

        [TestMethod]
        public void TestParallelTrapezoidalArea4()
        {
        }
    }
}
