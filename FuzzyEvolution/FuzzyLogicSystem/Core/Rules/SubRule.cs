using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogicSystems.Core.Rules
{
    public class SubRule : Rule
    {
        private readonly Rule _parent;

        internal SubRule(List<IRulePart> ruleParts, Rule parent)
            : base(ruleParts, parent.Categories, parent.Result)
        {
            _parent = parent;
        }

        internal Rule Parent { get => _parent; }
    }
}
