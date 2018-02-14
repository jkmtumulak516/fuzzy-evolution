using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogicSystems.Core
{
    public interface IFuzzyLogicSystem
    {
        IFuzzifier Fuzzifier { get; }
        IDefuzzifier Defuzzifier { get; }
        IFuzzyRuleBase RuleBase { get; }

        float Evaluate(IDictionary<int, float> crispValues);
    }
}
