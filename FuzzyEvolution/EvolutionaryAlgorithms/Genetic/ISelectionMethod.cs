using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ISelectionMethod
    {
        IList<Tuple<T, T>> SelectPairings<T>(IList<T> population) where T : IOrganism;
    }
}
