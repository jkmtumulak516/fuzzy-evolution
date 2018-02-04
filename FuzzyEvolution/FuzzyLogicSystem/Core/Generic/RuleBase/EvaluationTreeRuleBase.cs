using System;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Rules;

namespace FuzzyLogicSystems.Core.Generic.RuleBase
{
    public partial class EvaluationTreeRuleBase : IFuzzyRuleBase
    {
        private readonly IDictionary<int, FuzzySet<InputFuzzyMember>> _input_fuzzy_sets;
        private readonly FuzzySet<ResultFuzzyMember> _result_fuzzy_set;
        private readonly IList<Rule> _rules;
        private readonly EvaluationTree _evaluator;

        public EvaluationTreeRuleBase(IList<FuzzySet<InputFuzzyMember>> inputFuzzySets, FuzzySet<ResultFuzzyMember> resultFuzzySet, IList<Rule> rules)
        {
            _input_fuzzy_sets = new Dictionary<int, FuzzySet<InputFuzzyMember>>();
            _result_fuzzy_set = resultFuzzySet;
            _rules = rules;
            _evaluator = new EvaluationTree(inputFuzzySets, rules);

            foreach (var fuzzySet in inputFuzzySets)
                _input_fuzzy_sets.Add(fuzzySet.Category, fuzzySet);
        }

        public IDictionary<int, FuzzySet<InputFuzzyMember>> InputFuzzySets { get => _input_fuzzy_sets; }
        public FuzzySet<ResultFuzzyMember> ResultFuzzySet { get => _result_fuzzy_set; }
        public IList<Rule> Rules { get => _rules; }
        private EvaluationTree Evaluator { get => _evaluator; }

        public IList<FuzzyValue<ResultFuzzyMember>> Evaluate(IDictionary<int, IList<FuzzyValue<InputFuzzyMember>>> fuzzyValues)
        {
            throw new NotImplementedException();
        }
    }
}
