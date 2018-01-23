using System;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules.Operators
{
    internal class NotOperator : RuleOperator
    {
        private static NotOperator _instance = null;

        private NotOperator() : base(BooleanOperator.NOT) { }

        internal static NotOperator Get
        {
            get
            {
                if (_instance == null)
                    _instance = new NotOperator();

                return _instance;
            }
        }

        public override void Evaluate(IDictionary<int, string> fuzzifiedValues, Stack<bool> operandStack)
        {
            bool top = operandStack.Pop();
            operandStack.Push(!top);
        }

        public override void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack)
        {
            if (operatorStack.Count == 0)
            {
                postFix.Add(this);
                return;
            }

            else if (operatorStack.Peek().OperatorType == BooleanOperator.NOT)
                postFix.Add(operatorStack.Pop());

            operatorStack.Push(this);
        }
    }
}
