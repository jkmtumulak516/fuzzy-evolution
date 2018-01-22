using System;

namespace FuzzyLogicSystems.Util
{
    public static class MathUtil
    {
        public static float GaussianDistance(float height, float center, float width, float value)
        {
            return height * E(-Math.Pow(value - center, 2) / (2 * Math.Pow(width, 2)));
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
