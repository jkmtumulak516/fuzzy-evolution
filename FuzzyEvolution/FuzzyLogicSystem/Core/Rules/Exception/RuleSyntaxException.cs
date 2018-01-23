
namespace FuzzyLogicSystem.Core.Rules.Exception
{
    public class RuleSyntaxException : System.Exception
    {
        internal RuleSyntaxException() { }
        internal RuleSyntaxException(string message) : base(message) { }
        internal RuleSyntaxException(string message, System.Exception inner) : base(message, inner) { }
    }
}
