using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Rules;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyRuleBase
    {
        IDictionary<int, FuzzySet<InputFuzzyMember>> InputFuzzySets { get;}
        FuzzySet<ResultFuzzyMember> ResultFuzzySet { get; }
        IList<Rule> Rules { get; }

        IList<FuzzyValue<ResultFuzzyMember>> Evaluate(IDictionary<int, IList<FuzzyValue<InputFuzzyMember>>> fuzzyValues);
    }
}
