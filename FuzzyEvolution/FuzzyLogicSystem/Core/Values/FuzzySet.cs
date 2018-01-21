using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogicSystem.Core.Values
{
    public abstract class FuzzySet
    {
        private readonly int _category;
        private readonly HashSet<IFuzzyMember> _members;

        public FuzzySet(int category)
        {
            _category = category;
            _members = new HashSet<IFuzzyMember>(InitializeMembers());
        }

        public int Category { get => _category; }
        public HashSet<IFuzzyMember> Members { get => _members; }

        protected abstract ISet<IFuzzyMember> InitializeMembers();
    }
}
