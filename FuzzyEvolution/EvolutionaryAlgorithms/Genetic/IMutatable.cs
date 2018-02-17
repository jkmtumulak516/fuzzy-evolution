using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IMutatable
    {
        bool CanMutate { get; }

        void Mutate(float seed);
    }
}
