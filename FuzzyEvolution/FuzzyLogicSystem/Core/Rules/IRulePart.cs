using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    internal interface IRulePart
    {
        void Evaluate(IDictionary<int, FuzzyValue<IInputFuzzyMember>> fuzzifiedValues, Stack<bool> operandStack);
        void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack);
    }
}
