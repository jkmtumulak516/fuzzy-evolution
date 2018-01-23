
namespace FuzzyLogicSystems.Core.Values
{
    // class for containing fuzzymembers that fuzzifiy crisp values
    public abstract class InputFuzzyMember : FuzzyMember
    {
        private readonly bool _ceil_left;
        private readonly bool _ceil_right;

        public InputFuzzyMember(string name, int category, float peak,
            bool ceilLeft, bool ceilRight, float baseHalfWidth, float peakHalfWidth = 0.0f) 
            : base(name, category, peak, baseHalfWidth, peakHalfWidth)
        {
            _ceil_left = ceilLeft;
            _ceil_right = ceilRight;
        }
    
        public bool CeilLeft { get => _ceil_left; }
        public bool CeilRight { get => _ceil_right; }

        public abstract float GetMembership(float crispValue);
    }
}
