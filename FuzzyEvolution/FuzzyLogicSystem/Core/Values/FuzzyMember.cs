
namespace FuzzyLogicSystem.Core.Values
{
    public abstract class FuzzyMember : IFuzzyMember
    {
        private readonly string _name;
        private readonly int _category;
        private readonly float _center;
        private readonly float _coverage;
        private readonly float _upper_coverage;

        public FuzzyMember(string name, int category, float center, float coverage, float upperCoverage)
        {
            _name = name;
            _category = category;
            _center = center;
            _coverage = coverage;
            _upper_coverage = upperCoverage;
        }

        public string Name { get => _name; }
        public int Category { get => _category; }
        public float Center { get => _center; }
        public float Coverage { get => _coverage; }
        public float UpperCoverage { get => _upper_coverage; }
    }
}
