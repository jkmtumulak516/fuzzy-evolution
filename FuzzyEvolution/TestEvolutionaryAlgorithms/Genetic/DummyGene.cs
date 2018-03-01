using EvolutionaryAlgorithms.Genetic;

namespace TestEvolutionaryAlgorithms.Genetic
{
    public class DummyGene : IGene<DummyGene>
    {
        private int _value;

        public DummyGene(int value)
        {
            _value = value;
        }

        public int Value { get => _value; }

        public void Mutate(float seed)
        {
            if (seed < .5f)
                _value--;
            else 
                _value++;
        }
    }
}
