using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ICrossoverMethod
    {
        Tuple<IOrganism, IOrganism> CrossoverPairing(IOrganism o1, IOrganism o2);
    }
}
