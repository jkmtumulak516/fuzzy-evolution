using System.Collections.Generic;
using EvolutionaryAlgorithms.Genetic;

namespace FuzzyLogicSystems.Core.Rules
{
    public class RuleCopier : IGeneCopier<Rule>
    {
        public Rule DeepCopy(Rule gene)
        {
            var ruleParts = new List<IRulePart>(gene.RuleParts.Count);

            foreach (var rulePart in gene.RuleParts)
                ruleParts.Add(rulePart);

            return new ParentRule(ruleParts, gene.Result);
        }
    }
}
