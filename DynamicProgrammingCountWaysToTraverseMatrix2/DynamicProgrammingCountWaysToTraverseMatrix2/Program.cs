using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingCountWaysToTraverseMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CountWays(5, 5);
        }

        public static int CountWays(int m, int n)
        {
            var visited = new Dictionary<Tuple<int, int>, int>();
            return CountWays(m - 1, n - 1, visited);
        }
        public static int CountWays(int m, int n, Dictionary<Tuple<int, int>, int> visited)
        {
            if (m == 0 && n == 0) return 1;
            var count = 0;
            var t = new Tuple<int, int>(m, n);
            if (!visited.TryGetValue(t, out count))
            {
                var top = m == 0 ? 0 : CountWays(m - 1, n, visited);
                var left = n == 0 ? 0 : CountWays(m, n - 1, visited);
                visited.Add(t, top + left);
            }

            return visited[t];
        }
    }
}
