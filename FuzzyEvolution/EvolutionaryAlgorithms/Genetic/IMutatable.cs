
namespace EvolutionaryAlgorithms.Genetic
{
    public interface IMutatable
    {
        bool CanMutate { get; }

        void Mutate(float seed);
    }
}
