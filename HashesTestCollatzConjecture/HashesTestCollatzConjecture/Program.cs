using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesTestCollatzConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = TestCollatz(7);
        }

        public static HashSet<int> TestCollatz(int n)
        {
            if (n <= 2) return new HashSet<int>() { 1,2};
            var visited = new HashSet<int>();
            for (int i = 3; i <= n; i += 2)
            {
                var sequence = new HashSet<int>();
                int t = i;
                while (t != 1)
                {
                    if (!sequence.Add(t)) return null; //loop
                    if (visited.Add(t))
                    {
                        if (t % 2 == 0) t /= 2;
                        else { t *= 3; t++; }
                    }
                    else break;
                }
            }

            return visited;
        } 
    }
}
