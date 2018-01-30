using System.Collections.Generic;
using FuzzyLogicSystems.Core;

namespace FuzzyLogicSystems.Core.Values
{
    public abstract class FuzzySet<T> where T : IFuzzyMember
    {
        private readonly int _category;
        private readonly HashSet<T> _members;

        public FuzzySet(int category)
        {
            _category = category;
            _members = new HashSet<T>(InitializeMembers());
        }

        public int Category { get => _category; }
        public HashSet<T> Members { get => _members; }

        protected abstract ISet<T> InitializeMembers();
    }
}
