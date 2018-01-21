namespace FuzzyLogicSystem.Core.Values
{
    // should i use a template for this???
    // immutable
    public class FuzzyValue
    {
        // immutability
        private readonly float _degree;
        private readonly IFuzzyMember _fuzzyMember;

        public FuzzyValue(float degree, IFuzzyMember fuzzyMember)
        {
            _degree = degree;
            _fuzzyMember = fuzzyMember;
        }

        public float Degree { get => _degree; }
        public IFuzzyMember FuzzyMember { get => _fuzzyMember; }
    }
}
