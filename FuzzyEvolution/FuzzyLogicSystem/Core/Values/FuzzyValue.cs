namespace FuzzyLogicSystems.Core.Values
{
    // should i use a template for this???
    // immutable
    public class FuzzyValue<T> where T : IFuzzyMember
    {
        // immutability
        private readonly float _degree;
        private readonly T _fuzzyMember;

        public FuzzyValue(float degree, T fuzzyMember)
        {
            _degree = degree;
            _fuzzyMember = fuzzyMember;
        }

        public float Degree { get => _degree; }
        public T FuzzyMember { get => _fuzzyMember; }
    }
}
