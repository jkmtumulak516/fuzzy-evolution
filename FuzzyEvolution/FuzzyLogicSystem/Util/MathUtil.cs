using System;

namespace FuzzyLogicSystems.Util
{
    public static class MathUtil
    {
        public static float GaussianDistance(float x, float mu, float sigma)
        {
            float sigmaSquared =(float)Math.Pow(sigma, 2);
            return E(-Math.Pow(x - mu, 2) / (2 * sigmaSquared)) / (float)Math.Sqrt(2 * Math.PI * sigmaSquared);
        }

        public static float LinearDistance(float point1, float point2, float max = 1.0f)
        {
            return Math.Abs(point1 - point2) / max;
        }

        // assumese dimensions given are valid for a parallel trapezoid
        public static float ParallelTrapezoidalArea(float height, float upperWidth, float lowerWidth)
        {
            return (height * (upperWidth + lowerWidth)) / 2.0f;
        }

        public static float E(double exp)
        {
            return (float)Math.Pow(Math.E, exp);
        }
    }
}
