using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public sealed class LinearResult : IResultFuzzyMember
    {
        private readonly string _name;
        private readonly int _category;
        private readonly float _peak;
        private readonly float _base_half_width;
        private readonly float _peak_half_width;

        private readonly string _print_output;

        public LinearResult(string name, FuzzySet<IResultFuzzyMember> containingSet, float peak,
            float baseHalfWidth, float peakHalfWidth = 0.0f)
        {
            _name = name;
            _category = containingSet.Category;
            _peak = peak;
            _base_half_width = baseHalfWidth;
            _peak_half_width = peakHalfWidth;

            _print_output = Category + " : " + Name;
        }

        public string Name { get => _name; }
        public int Category { get => _category; }
        public float Peak { get => _peak; }
        public float BaseHalfWidth { get => _base_half_width; }
        public float PeakHalfWidth { get => _peak_half_width; }

        public bool Contains(float degree)
        {
            return Math.Abs(Peak - degree) < BaseHalfWidth;
        }

        // degree is assumed to be a value between 0 and 1 representing a percentage
        public float GetArea(float degree)
        {
            float effectiveCoverage = BaseHalfWidth * 2;
            float effectiveUpperCoverage = PeakHalfWidth * 2;

            if (degree > 1.0f || degree < 0.0f) throw new ArgumentException
                    ("Parameter 'degree' must be a value between 0 and 1 inclusive. [degree = " + degree.ToString() + "]");
            else if (degree == 1.0f)
                return MathUtil.ParallelTrapezoidalArea(1.0f, PeakHalfWidth + PeakHalfWidth, BaseHalfWidth + BaseHalfWidth);
            else
                return MathUtil.ParallelTrapezoidalArea(1.0f,
                    effectiveUpperCoverage + (effectiveCoverage - effectiveUpperCoverage) * (1.0f - degree),
                    effectiveCoverage);
        }

        public bool Equals(IFuzzyMember other)
        {
            return Category == other.Category && Name.Equals(other.Name);
        }
    }
}
