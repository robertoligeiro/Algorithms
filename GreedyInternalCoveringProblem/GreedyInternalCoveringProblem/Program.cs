using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyInternalCoveringProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(3, 4), new Tuple<int, int>(2, 6), new Tuple<int, int>(6, 9) };

            var r = GetMinNumberVisits(i);
        }

        public static IList<int> GetMinNumberVisits(IList<Tuple<int, int>> tasks)
        {
            var resp = new List<Tuple<int,int>>();
            tasks = tasks.OrderBy(x => x.Item1).ToList();

            resp.Add(tasks[0]);
            tasks.RemoveAt(0);
            while (tasks.Count > 0)
            {
                if (!HasInter(resp[resp.Count - 1], tasks[0]))
                {
                    resp.Add(tasks[0]);
                }
                else
                {
                    resp[resp.Count - 1] = GetInterNode(resp[resp.Count - 1], tasks[0]);
                }
                tasks.RemoveAt(0);
            }

            return resp.Select(x => x.Item1).ToList();
        }

        public static bool HasInter(Tuple<int, int> a, Tuple<int, int> b)
        {
            return b.Item1 <= a.Item2;
        }
        public static Tuple<int,int> GetInterNode(Tuple<int, int> a, Tuple<int, int> b)
        {
            return new Tuple<int, int>(Math.Max(a.Item1, b.Item1), Math.Min(a.Item2, b.Item2));
        }
    }
}
