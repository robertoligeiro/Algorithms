using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackEvaluateRpnExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = EvalRpn("3,40,+,2,x,-1,+"); 
        }

        public static int EvalRpn(string exp)
        {
            var s = new Stack<int>();
            var expArray = exp.Split(',');
            foreach (var c in expArray)
            {
                if (c.Length > 1 || char.IsDigit(c[0]))
                {
                    s.Push(Convert.ToInt32(c));
                    continue;
                }

                var b = s.Pop();
                var a = s.Pop();
                switch (c)
                {
                    case "+":
                        s.Push(a + b);
                        break;
                    case "-":
                        s.Push(a - b);
                        break;
                    case "x":
                        s.Push(a * b);
                        break;
                    case "/":
                        s.Push(a / b);
                        break;
                }
            }

            return s.Pop();
        }
    }
}
