using System;
using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    internal class RuleOperand : IRulePart
    {
        private readonly int _category;
        private readonly string _name;

        internal RuleOperand(int category, string name)
        {
            _category = category;
            _name = name;
        }

        internal int Category { get => _category; }
        internal string Name { get => _name; }

        public void Evaluate(IDictionary<int, string> fuzzifiedValues, Stack<bool> operandStack)
        {
            bool value = false;

            if (fuzzifiedValues.ContainsKey(Category))
                value = fuzzifiedValues[Category].Equals(Name);

            operandStack.Push(value);
        }

        public void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack)
        {
            postFix.Add(this);
        }
    }
}
