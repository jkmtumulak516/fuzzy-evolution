using System;

namespace FuzzyLogicSystems.Core.Values
{
    public abstract class FuzzyMember : IFuzzyMember
    {
        private readonly string _name;
        private readonly int _category;
        private readonly float _peak;
        private readonly float _base_half_width;
        private readonly float _peak_half_width;

        public FuzzyMember(string name, int category, float peak, float baseHalfWidth, float peakHalfWidth)
        {
            _name = name;
            _category = category;
            _peak = peak;
            _base_half_width = baseHalfWidth;
            _peak_half_width = peakHalfWidth;
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
    }
}
