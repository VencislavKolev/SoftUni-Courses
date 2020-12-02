namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> openBrackets = new Stack<char>();

            foreach (char bracket in parentheses)
            {
                char expBracket = default;

                switch (bracket)
                {
                    case ')':
                        expBracket = '(';
                        break;
                    case ']':
                        expBracket = '[';
                        break;
                    case '}':
                        expBracket = '{';
                        break;
                    default:
                        openBrackets.Push(bracket);
                        break;
                }
                if (expBracket == default)
                {
                    continue;
                }
                if (openBrackets.Pop() != expBracket)
                {
                    return false;
                }
            }

            return openBrackets.Count == 0;
        }
    }
}
