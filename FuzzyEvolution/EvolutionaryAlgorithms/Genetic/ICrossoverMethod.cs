using System;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ICrossoverMethod
    {
        Tuple<IOrganism, IOrganism> CrossoverPairing(IOrganism o1, IOrganism o2);
    }
}
