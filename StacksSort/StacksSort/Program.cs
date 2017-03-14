using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = SortStack(new Stack<int>(new int[] { 2, 3, 6, 4, 5 }));
        }

        public static Stack<int> SortStack(Stack<int> a)
        {
            var r = new Stack<int>();
            while (a.Count > 0)
            {
                var t = a.Pop();
                while (r.Count > 0 && r.Peek() > t)
                {
                    a.Push(r.Pop());
                }
                r.Push(t);
            }

            return r;
        }
    }
}
