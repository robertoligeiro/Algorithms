using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphComputeEnclosedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            var region = new List<List<char>>()
            {
                new List<char> { 'b', 'b', 'b', 'b'},
                new List<char> { 'b', 'w', 'w', 'b'},
                new List<char> { 'b', 'b', 'w', 'b'},
                new List<char> { 'b', 'w', 'w', 'b'},
            };

            ComputeEnclosedRegions(region);
        }

        public static void ComputeEnclosedRegions(List<List<char>> region)
        {
            var visited = new HashSet<Tuple<int, int>>();
            ComputeBorders(region, visited);
            for (int i = 0; i < region.Count; ++i)
            {
                for (int j = 0; j < region.Count; ++j)
                {
                    var t = new Tuple<int, int>(i, j);
                    if (!visited.Contains(t) && region[i][j] == 'w')
                    {
                        GetPathFrom(t, region, visited, true);
                    }
                }
            }
        }

        public static void ComputeBorders(List<List<char>> region, HashSet<Tuple<int, int>> visited)
        {
            for (int i = 0; i < region.FirstOrDefault().Count; ++i)
            {
                if (region.FirstOrDefault().ElementAt(i) == 'w')
                {
                    var t = new Tuple<int, int>(0, i);
                    GetPathFrom(t, region, visited, false);
                }
                if (region.LastOrDefault().ElementAt(i) == 'w')
                {
                    var t = new Tuple<int, int>(region.Count - 1, i);
                    GetPathFrom(t, region, visited, false);
                }
                if (region[i][0] == 'w')
                {
                    var t = new Tuple<int, int>(i, 0);
                    GetPathFrom(t, region, visited, false);
                }
                if (region[i][region.Count - 1] == 'w')
                {
                    var t = new Tuple<int, int>(i, region.Count - 1);
                    GetPathFrom(t, region, visited, false);
                }
            }
        }

        public static void GetPathFrom(Tuple<int, int> s, List<List<char>> region, HashSet<Tuple<int, int>> visited, bool changeColor)
        {
            var n = new Stack<Tuple<int, int>>();
            n.Push(s);
            while (n.Count > 0)
            {
                var curr = n.Pop();
                if (!visited.Contains(curr))
                {
                    GetNeibrohs(curr, region, n, region.Count - 1);
                    visited.Add(curr);
                    if (changeColor) region[curr.Item1][curr.Item2] = 'b';
                }
            }
        }

        public static void GetNeibrohs(Tuple<int, int> s, List<List<char>> region, Stack<Tuple<int, int>> c, int border)
        {
            if (s.Item1 > 0)
            {
                if(region[s.Item1 - 1][s.Item2] == 'w')
                    c.Push(new Tuple<int, int>(s.Item1 - 1, s.Item2));
            }
            if (s.Item1 < border)
            {
                if (region[s.Item1 + 1][s.Item2] == 'w')
                    c.Push(new Tuple<int, int>(s.Item1 + 1, s.Item2));
            }
            if (s.Item2 > 0)
            {
                if (region[s.Item1][s.Item2 - 1] == 'w')
                    c.Push(new Tuple<int, int>(s.Item1, s.Item2 - 1));
            }
            if (s.Item2 < border)
            {
                if (region[s.Item1][s.Item2 + 1] == 'w')
                    c.Push(new Tuple<int, int>(s.Item1, s.Item2 + 1));
            }
        }
    }
}
