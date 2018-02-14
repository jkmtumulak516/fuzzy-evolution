using System.Linq;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Generic.RuleBase.Util;

namespace FuzzyLogicSystems.Core.Generic.RuleBase
{
    public partial class EvaluationTreeRuleBase : IFuzzyRuleBase
    {
        private readonly IDictionary<int, FuzzySet<IInputFuzzyMember>> _input_fuzzy_sets;
        private readonly FuzzySet<IResultFuzzyMember> _result_fuzzy_set;
        private readonly IList<ParentRule> _parent_rules;
        private readonly EvaluationTree _evaluator;

        public EvaluationTreeRuleBase(IList<FuzzySet<IInputFuzzyMember>> inputFuzzySets, FuzzySet<IResultFuzzyMember> resultFuzzySet, IList<ParentRule> parentRules)
        {
            _input_fuzzy_sets = new Dictionary<int, FuzzySet<IInputFuzzyMember>>();
            _result_fuzzy_set = resultFuzzySet;
            _parent_rules = parentRules;
            _evaluator = new EvaluationTree(inputFuzzySets, parentRules);

            foreach (var fuzzySet in inputFuzzySets)
                _input_fuzzy_sets.Add(fuzzySet.Category, fuzzySet);
        }

        public IDictionary<int, FuzzySet<IInputFuzzyMember>> InputFuzzySets { get => _input_fuzzy_sets; }
        public FuzzySet<IResultFuzzyMember> ResultFuzzySet { get => _result_fuzzy_set; }
        private EvaluationTree Evaluator { get => _evaluator; }
        
        public IList<FuzzyValue<IResultFuzzyMember>> Evaluate(IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzyValues)
        {
            // combine the fuzzified values of different 
            var combinations = new CombinationFinder().FindCombinations(fuzzyValues.Values.ToList());
            var resultList = new List<FuzzyValue<IResultFuzzyMember>>(combinations.Count);

            foreach (var combination in combinations)
            {
                var combinedFuzzyValues = combination.ToDictionary(x => x.FuzzyMember.Category, x => x);
                var results = Evaluator.Evaluate(combinedFuzzyValues);

                var degree = combinedFuzzyValues.Values.Min(x => x.Degree);

                foreach (var result in results)
                    resultList.Add(new FuzzyValue<IResultFuzzyMember>(degree, result));
            }

            return resultList;
        }
    }
}
