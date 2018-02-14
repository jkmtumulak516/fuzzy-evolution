using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyRuleBase
    {
        IDictionary<int, FuzzySet<IInputFuzzyMember>> InputFuzzySets { get;}
        FuzzySet<IResultFuzzyMember> ResultFuzzySet { get; }

        IList<FuzzyValue<IResultFuzzyMember>> Evaluate(IDictionary<int, IList<FuzzyValue<IInputFuzzyMember>>> fuzzyValues);
    }
}
