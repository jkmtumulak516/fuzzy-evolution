﻿using System;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Rules;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules.Operators
{
    internal class OrOperator : RuleOperator
    {
        private static OrOperator _instance = null;

        private OrOperator() : base(BooleanOperator.OR) { }

        internal static OrOperator Get
        {
            get
            {
                if (_instance == null)
                    _instance = new OrOperator();

                return _instance;
            }
        }

        public override void Evaluate(IDictionary<int, string> fuzzifiedValues, Stack<bool> operandStack)
        {
            bool var1 = operandStack.Pop();
            bool var2 = operandStack.Pop();

            operandStack.Push(var1 || var2);
        }

        public override void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack)
        {
            if (operatorStack.Count == 0)
            {
                postFix.Add(this);
                return;
            }

            else if (operatorStack.Peek().OperatorType != BooleanOperator.OR)
            {
                postFix.Add(operatorStack.Pop());

                while (operatorStack.Count > 0 &&
                    operatorStack.Peek().OperatorType != BooleanOperator.NOT)
                    postFix.Add(operatorStack.Pop());
            }

            else if (operatorStack.Count > 0 && 
                operatorStack.Peek().OperatorType == BooleanOperator.NOT)
                postFix.Add(operatorStack.Pop());

            operatorStack.Push(this);
        }
    }
}