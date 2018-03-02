using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic.Generic
{
    public class GeneticAlgorithm<O, G> : IGeneticAlgorithm<O, G> where O : IOrganism<O, G> where G : IGene<G>
    {
        private readonly ISelectionMethod _selector;
        private readonly ICrossoverMethod _crossover;
        private readonly IOrganismFactory<O, G> _organism_factory;
        private readonly IGeneCopier<G> _gene_factory;

        private readonly Random _random;

        public GeneticAlgorithm(ISelectionMethod selectionMethod, ICrossoverMethod crossoverMethod, IOrganismFactory<O, G> organismFactory, IGeneCopier<G> geneFactory)
        {
            _selector = selectionMethod ?? throw new NullReferenceException();
            _crossover = crossoverMethod ?? throw new NullReferenceException();
            _organism_factory = organismFactory ?? throw new NullReferenceException();
            _gene_factory = geneFactory ?? throw new NullReferenceException();

            _random = new Random();
        }

        public ISelectionMethod SelectionMethod { get => _selector; }
        public ICrossoverMethod CrossoverMethod { get => _crossover; }
        public IOrganismFactory<O, G> OrganismFactory { get => _organism_factory; }
        public IGeneCopier<G> GeneFactory { get => _gene_factory; }

        public IList<O> BreedNewGeneration(IList<O> population, float mutationChance)
        {
            if (mutationChance > 1f || mutationChance < 0f) throw new ArgumentException("Parameter mutationChance must lie between 0.00 and 1.00 inclusive.");

            var newGeneration = new List<O>(population.Count);
            var pairings = SelectionMethod.SelectPairings<O, G>(population);

            foreach (var pairing in pairings)
            {
                var bredOrganisms = CrossoverMethod.CrossoverGenes(pairing.Item1, pairing.Item2, OrganismFactory, GeneFactory);

                MutateGenes(bredOrganisms.Item1, mutationChance);
                MutateGenes(bredOrganisms.Item2, mutationChance);

                newGeneration.Add(bredOrganisms.Item1);
                newGeneration.Add(bredOrganisms.Item2);
            }

            return newGeneration;
        }

        private void MutateGenes(O organism, float mutationChance)
        {
            foreach (var gene in organism.Genes)
            {
                if (_random.NextDouble() < mutationChance)
                    gene.Mutate((float)_random.NextDouble());
            }
        }
    }
}
