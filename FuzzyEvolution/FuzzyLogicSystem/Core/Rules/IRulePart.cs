using System;
using System.Collections.Generic;

namespace FuzzyLogicSystems.Core.Rules
{
    internal interface IRulePart
    {
        void Evaluate(IDictionary<int, string> fuzzifiedValues, Stack<bool> operandStack);
        void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack);
    }
}
