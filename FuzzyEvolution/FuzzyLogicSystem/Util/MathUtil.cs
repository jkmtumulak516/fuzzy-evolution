using System;

namespace FuzzyLogicSystems.Util
{
    public static class MathUtil
    {
        public static float GaussianDistance(float height, float center, float width, float value)
        {
            return height * E(Math.Pow((value - center) / (width / 4.0f), 2.0) / -2.0f);
        }

        public static float LinearDistance(float center, float value, float bounds = 1.0f)
        {
            if (bounds <= 0) throw new ArgumentException(
                "Parameter 'bounds' must be greater than 0. [bounds = " + bounds.ToString() + "]");

            float rawDistance = Math.Abs(center - value) / bounds;
            return rawDistance > 1.0f ? 0.0f : 1.0f - rawDistance;
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
