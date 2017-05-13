using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode218.TheSkylineProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] buildings = new int[,] { { 1, 4, 4}, { 2, 5, 5 }, { 3, 7, 2 }, { 8,9,1} };
            int[,] buildings = new int[,] { { 1, 4, 4 }, { 2, 5, 5 }, { 3, 7, 2 }};
            var s = new Solution();
            var r = s.GetSkyline(buildings);
        }

        public class building
        {
            public int id;
            public int start;
            public int end;
            public int h;
            public Tuple<int, int> topEdge;
            public Queue<Tuple<int, int>> coords;
            public building(int id, int l, int r, int h)
            {
                this.start = l;
                this.end = r;
                this.h = h;
                this.id = id;
                coords = new Queue<Tuple<int, int>>();
                coords.Enqueue(new Tuple<int, int>(l, h));
                coords.Enqueue(new Tuple<int, int>(r - l, h));
                this.topEdge = new Tuple<int, int>(r - l, h);
            }
        }
        public class Solution
        {
            public IList<int[]> GetSkyline(int[,] buildings)
            {
                var resp = new List<int[]>();
                if (buildings.GetLength(0) == 0 || buildings == null)
                {
                    return resp;
                }
                var lBuildings = new Dictionary<int, building>();
                for (int i = 0; i < buildings.GetLength(0); ++i)
                {
                    var nB = new building(i, buildings[i, 0], buildings[i, 1], buildings[i, 2]);
                    lBuildings.Add(i, nB);
                }

                var heap = new SortedDictionary<Tuple<int, int>, int>();
                foreach (var b in lBuildings.Values)
                {
                    var d = b.coords.Dequeue();
                    if(!heap.ContainsKey(d))
                        heap.Add(d, b.id);
                }

                var r = new List<Tuple<int, int>>();
                int lastAdded = 0;
                while (heap.Count > 0)
                {
                    var curr = heap.FirstOrDefault();
                    heap.Remove(curr.Key);

                    if (lBuildings[curr.Value].coords.Any())
                    {
                        var d = lBuildings[curr.Value].coords.Dequeue();
                        if (!heap.ContainsKey(d))
                            heap.Add(d, curr.Value);
                    }

                    if (r.Count == 0)
                    {
                        r.Add(curr.Key);
                        lastAdded = curr.Value;
                        continue;
                    }
                    if (lBuildings[lastAdded].end < curr.Key.Item1)
                    {
                        r.Add(new Tuple<int, int>(lBuildings[lastAdded].end, 0));
                        r.Add(curr.Key);
                        lastAdded = curr.Value;
                        continue;
                    }
                    if (r.Last().Item2 < curr.Key.Item2)
                    {
                        if (r.Last().Item2 == 0)
                        {
                            if (lBuildings[curr.Value].start < lBuildings[lastAdded].end)
                            {
                                r.RemoveAt(r.Count - 1);
                                r.Add(new Tuple<int, int>(lBuildings[lastAdded].end, lBuildings[curr.Value].h));
                                lastAdded = curr.Value;
                            }
                        }
                        else
                        {
                            r.Add(curr.Key);
                            lastAdded = curr.Value;
                        }
                    }
                    else
                    {
                        if (lastAdded == curr.Value && curr.Key == lBuildings[curr.Value].topEdge)
                        {
                            r.Add(new Tuple<int, int>(curr.Key.Item1, 0));
                            lastAdded = curr.Value;
                        }
                    }
                }

                r.Add(new Tuple<int, int>(lBuildings[lastAdded].end, 0));
                foreach (var tt in r)
                {
                    resp.Add(new int[] { tt.Item1, tt.Item2 });
                }
                return resp;
            }
        }
    }
}
