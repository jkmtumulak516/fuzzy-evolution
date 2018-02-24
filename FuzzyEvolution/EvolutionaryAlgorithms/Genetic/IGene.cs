
namespace EvolutionaryAlgorithms.Genetic
{
    public interface IGene<G> where G : IGene<G>
    {
        void Mutate(float seed);
    }
}
