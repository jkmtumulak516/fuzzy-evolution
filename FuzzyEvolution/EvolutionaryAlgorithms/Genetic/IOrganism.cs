using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface IOrganism : IMutatable
    {
        float Fitness { get; }
        IList<IGene> Genes { get; }
    }
}
