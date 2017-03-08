using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksWellFormedExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = IsWellFormed("(");
            b = IsWellFormed("()");
            b = IsWellFormed("{[()]}");
            b = IsWellFormed("()[()]{}");
            b = IsWellFormed("(}");
            b = IsWellFormed("[()[]{()");
        }

        public static bool IsWellFormed(string exp)
        {
            var s = new Stack<char>();
            foreach (var c in exp)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    s.Push(c);
                }
                else
                {
                    if (s.Count == 0) return false;
                    char top = s.Pop();
                    if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{')) return false;
                }
            }
            return s.Count == 0;
        }
    }
}
