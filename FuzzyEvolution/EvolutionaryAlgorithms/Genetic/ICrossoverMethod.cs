using System;

namespace EvolutionaryAlgorithms.Genetic
{
    public interface ICrossoverMethod
    {
        Tuple<O, O> CrossoverGenes<O, G>(O o1, O o2, IOrganismFactory<O, G> organismFactory, IGeneCopier<G> geneCopier) where O : IOrganism<O, G> where G : IGene<G>;
    }
}
