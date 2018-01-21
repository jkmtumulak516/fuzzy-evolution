using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogicSystem.Core.Values
{
    internal interface IFuzzyMember
    {
        string Name { get; }
        int Id { get; }
        int Category { get; }
        float Center { get; }
        float Coverage { get; }
        float UpperCoverage { get; }
    }
}
