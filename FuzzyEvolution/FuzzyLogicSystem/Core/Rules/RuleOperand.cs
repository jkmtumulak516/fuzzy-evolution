﻿using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;

namespace FuzzyLogicSystems.Core.Rules
{
    internal class RuleOperand : IRulePart
    {
        private readonly IFuzzyMember _fuzzy_member;

        internal RuleOperand(IFuzzyMember fuzzyMember)
        {
            _fuzzy_member = fuzzyMember;
        }

        internal IFuzzyMember FuzzyMember { get => _fuzzy_member; }

        public void Evaluate(IDictionary<int, FuzzyValue<InputFuzzyMember>> fuzzifiedValues, Stack<bool> operandStack)
        {
            bool value = false;

            if (fuzzifiedValues.ContainsKey(FuzzyMember.Category))
                value = fuzzifiedValues[FuzzyMember.Category].FuzzyMember.Name.Equals(FuzzyMember.Name);

            operandStack.Push(value);
        }

        public void ToPostFix(IList<IRulePart> postFix, Stack<RuleOperator> operatorStack)
        {
            postFix.Add(this);
        }
    }
}
