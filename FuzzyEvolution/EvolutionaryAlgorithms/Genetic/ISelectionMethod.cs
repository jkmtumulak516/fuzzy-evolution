using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ISelectionMethod
    {
        IList<Tuple<O, O>> SelectPairings<O, G>(IList<O> population) where O : IOrganism<O, G> where G : IGene<G>;
    }
}
