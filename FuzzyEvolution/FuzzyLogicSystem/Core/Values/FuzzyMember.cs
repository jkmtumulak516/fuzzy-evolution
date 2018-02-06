using System;

namespace FuzzyLogicSystems.Core.Values
{
    public abstract class FuzzyMember : IFuzzyMember, IEquatable<FuzzyMember>
    {
        private readonly string _name;
        private readonly int _category;
        private readonly float _peak;
        private readonly float _base_half_width;
        private readonly float _peak_half_width;
        private readonly string _print_output;

        public FuzzyMember(string name, int category, float peak, float baseHalfWidth, float peakHalfWidth)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("A FuzzyMember must have a name.");

            _name = name;
            _category = category;
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

        public bool Equals(FuzzyMember other)
        {
            return Category == other.Category && Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return _print_output;
        }
    }
}
