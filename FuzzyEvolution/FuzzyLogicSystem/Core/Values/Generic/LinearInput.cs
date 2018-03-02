using System;
using FuzzyLogicSystems.Util;

namespace FuzzyLogicSystems.Core.Values.Generic
{
    public sealed class LinearInput : IInputFuzzyMember
    {
        private readonly string _name;
        private readonly FuzzySet<IInputFuzzyMember> _parent_set;
        private readonly float _peak;
        private readonly float _base_half_width;
        private readonly float _peak_half_width;
        private readonly bool _ceil_left;
        private readonly bool _ceil_right;

        private readonly string _print_output;

        public LinearInput(string name, FuzzySet<IInputFuzzyMember> parentSet, float peak,
            bool ceilLeft, bool ceilRight, float baseHalfWidth, float peakHalfWidth)
        {
            if (peakHalfWidth > baseHalfWidth)
                throw new ArgumentException("BaseHalfWidth must be greater than or equal to PeakHalfWidth.");

            _name = name;
            _parent_set = parentSet;
            _peak = peak;
            _base_half_width = baseHalfWidth;
            _peak_half_width = peakHalfWidth;
            _ceil_left = ceilLeft;
            _ceil_right = ceilRight;

            _print_output = Category + " : " + Name;
        }

        public string Name { get => _name; }
        public int Category { get => _parent_set.Category; }
        public FuzzySet<IInputFuzzyMember> ParentSet { get => _parent_set; }
        public float Peak { get => _peak; }
        public float BaseHalfWidth { get => _base_half_width; }
        public float PeakHalfWidth { get => _peak_half_width; }
        public bool CeilLeft { get => _ceil_left; }
        public bool CeilRight { get => _ceil_right; }

        public bool Contains(float degree)
        {
            return Math.Abs(Peak - degree) < BaseHalfWidth;
        }

        public float GetMembership(float crispValue)
        {
            float diffInCenterAndValue = Math.Abs(Peak - crispValue);

            if (CeilLeft && crispValue < Peak) return 1.0f;
            else if (CeilRight && crispValue > Peak) return 1.0f;
            else if (diffInCenterAndValue <= PeakHalfWidth) return 1.0f;
            
            float effectiveCenter = crispValue < Peak ? Peak - PeakHalfWidth : Peak + PeakHalfWidth;

            return diffInCenterAndValue < BaseHalfWidth ? MathUtil.LinearDistance(effectiveCenter, crispValue, BaseHalfWidth - PeakHalfWidth) : 0.0f;
        }

        public override string ToString()
        {
            return _print_output;
        }

        public bool Equals(IFuzzyMember<IInputFuzzyMember> other)
        {
            return Category == other.Category && Name.Equals(other.Name);
        }

        public int CompareTo(IInputFuzzyMember other)
        {
            return (int)Math.Round(Peak - other.Peak);
        }
    }
}
