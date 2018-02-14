using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules.Operators
{
    internal class AndOperator : RuleOperator
    {
        private static AndOperator _instance = null;

        private AndOperator() : base(BooleanOperator.AND) { }

        internal static AndOperator Get
        {
            get
            {
                if (_instance == null)
                    _instance = new AndOperator();

                return _instance;
            }
        }

        public override void Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues, Stack<bool> operandStack)
        {
            bool var1 = operandStack.Pop();
            bool var2 = operandStack.Pop();

            operandStack.Push(var1 && var2);
        }

        public override void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack)
        {
            if (operatorStack.Count == 0)
            {
                operatorStack.Push(this);
                return;
            }

            else if (operatorStack.Peek().OperatorType == BooleanOperator.AND)
                postFix.Add(operatorStack.Pop());

            operatorStack.Push(this);
        }

        public override string ToString()
        {
            return "AND";
        }
    }
}
