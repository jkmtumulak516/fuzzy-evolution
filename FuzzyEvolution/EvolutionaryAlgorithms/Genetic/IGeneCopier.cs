
namespace EvolutionaryAlgorithms.Genetic
{
    public interface IGeneCopier<G> where G : IGene<G>
    {
        G DeepCopy(G gene);
    }
}
