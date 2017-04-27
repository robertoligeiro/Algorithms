using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionHanoiTowers
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CalcHanoi(3);
        }

        public static Stack<int> CalcHanoi(int n)
        {
            var from = new Stack<int>();
            var to = new Stack<int>();
            var use = new Stack<int>();
            for (int i = n; i > 0; --i)
            {
                from.Push(i);
            }
            CalcHanoi(n, from, to, use);
            return to;
        }

        public static void CalcHanoi(int numToMove, Stack<int> from, Stack<int> to, Stack<int> use)
        {
            if (numToMove > 0)
            {
                CalcHanoi(numToMove - 1, from, use, to);
                to.Push(from.Pop());
                CalcHanoi(numToMove - 1, use, to, from);
            }
        }
    }
}
