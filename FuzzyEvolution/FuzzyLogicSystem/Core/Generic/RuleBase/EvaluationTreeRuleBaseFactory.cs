using System.Collections.Generic;
using System.Linq;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;
using EvolutionaryAlgorithms.Genetic;

namespace FuzzyLogicSystems.Core.Generic.RuleBase
{
    public class EvaluationTreeRuleBaseFactory : IOrganismFactory<EvaluationTreeRuleBase, Rule>
    {
        private readonly IList<FuzzySet<IInputFuzzyMember>> _input_sets;
        private readonly FuzzySet<IResultFuzzyMember> _result_set;

        public EvaluationTreeRuleBaseFactory(
            IList<FuzzySet<IInputFuzzyMember>> inputSets, FuzzySet<IResultFuzzyMember> resultSet)
        {
            _input_sets = inputSets;
            _result_set = resultSet;
        }

        public EvaluationTreeRuleBase Make(IList<Rule> genes)
        {
            return new EvaluationTreeRuleBase(_input_sets, _result_set, 
                (from gene in genes select gene).ToList().ConvertAll(x => (ParentRule)x));
        }
    }
}
