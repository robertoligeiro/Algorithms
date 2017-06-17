using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMaxAreaInTheSkyline
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CalcMaxAreInTheSkyline(new List<int>() { 1, 2, 4 });
            r = CalcMaxAreInTheSkyline(new List<int>() { 2, 1, 2, 3, 1 });
        }

        public static int CalcMaxAreInTheSkyline(List<int> a)
        {
            var s = new Stack<int>();
            var maxSoFar = 0;
            var i = 0;
            for (; i < a.Count;)
            {
                if (s.Count == 0 || a[s.Peek()] <= a[i]) s.Push(i++);
                else
                {
                    var top = s.Pop();
                    var localMax = 0;
                    if (s.Count == 0)
                    {
                        localMax = a[top] * i;
                    }
                    else
                    {
                        localMax = a[top] * (i - s.Peek() - 1);
                    }
                    maxSoFar = Math.Max(maxSoFar, localMax);
                }
            }

            if (s.Count == 0) return maxSoFar;

            while(s.Count > 0)
            {
                var top = s.Pop();
                var localMax = 0;
                if (s.Count == 0)
                {
                    localMax = a[top] * i;
                }
                else
                {
                    localMax = a[top] * (i - s.Peek() - 1);
                }
                maxSoFar = Math.Max(maxSoFar, localMax);
            }

            return maxSoFar;
        }
    }
}
