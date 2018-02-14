using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    internal enum BooleanOperator : int { OR = 0, AND = 1 } 

    internal abstract class RuleOperator : IRulePart
    {
        private readonly BooleanOperator _operator_type;

        internal RuleOperator(BooleanOperator operatorType)
        {
            _operator_type = operatorType;
        }

        public BooleanOperator OperatorType { get => _operator_type; }

        public abstract void Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues, Stack<bool> operandStack);
        public abstract void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack);
        public abstract override string ToString();
    }
}
