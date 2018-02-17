using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ISelectionMethod
    {
        IList<Tuple<IOrganism, IOrganism>> SelectPairings(IList<IOrganism> population);
    }
}
