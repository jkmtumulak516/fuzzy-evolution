using System;
using System.Collections.Generic;

namespace FuzzyLogicSystems.Core.Values
{
    public abstract class FuzzySet<T> where T : IFuzzyMember<T>
    {
        private readonly int _category;
        private readonly ISet<T> _members;

        public FuzzySet(int category)
        {
            _category = category;
            _members = new HashSet<T>(InitializeMembers());
        }

        public int Category { get => _category; }
        public ISet<T> Members { get => _members; }

        protected abstract ISet<T> InitializeMembers();
    }
}
