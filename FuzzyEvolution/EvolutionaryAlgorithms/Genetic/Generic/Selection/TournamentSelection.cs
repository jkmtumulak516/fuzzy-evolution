using System;
using System.Collections.Generic;

namespace EvolutionaryAlgorithms.Genetic.Generic.Selection
{
    public class TournamentSelection : ISelectionMethod
    {
        private readonly float _min_increment;
        private readonly float _max_increment;
        private readonly Random _random;

        private TournamentSelection()
        {
            _random = new Random();
        }

        public IList<Tuple<O, O>> SelectPairings<O, G>(IList<O> population)
            where O : IOrganism<O, G>
            where G : IGene<G>
        {


            throw new NotImplementedException();
        }
    }
}
