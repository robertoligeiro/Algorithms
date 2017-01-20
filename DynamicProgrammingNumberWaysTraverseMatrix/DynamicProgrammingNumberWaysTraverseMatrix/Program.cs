using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingNumberWaysTraverseMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var resp = CountWays(5, 5);
        }

        public static int CountWays(int n, int m)
        {
            var visited = new Dictionary<Tuple<int, int>, int>();
            return CountWays(n - 1, m - 1, visited);
        }

        public static int CountWays(int x, int y, Dictionary<Tuple<int, int>, int> visited)
        {
            if (x == 0 && y == 0) return 1;
            var t = new Tuple<int, int>(x, y);
            int count;
            if (!visited.TryGetValue(t, out count))
            {
                int topWays = x == 0 ? 0 : CountWays(x - 1, y, visited);
                int leftWays = y == 0 ? 0 : CountWays(x, y - 1, visited);

                count = topWays + leftWays;
                visited.Add(t, count);
            }

            return count;
        }
    }
}
