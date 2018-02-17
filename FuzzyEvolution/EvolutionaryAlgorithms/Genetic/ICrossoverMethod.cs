using System;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ICrossoverMethod
    {
        Tuple<T, T> CrossoverPairings<T>(T o1, T o2) where T : IOrganism;
    }
}
