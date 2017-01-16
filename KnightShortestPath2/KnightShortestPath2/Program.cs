using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightShortestPath2
{
    class Program
    {
        static void Main(string[] args)
        {
            var resp = ChessKnightWalk.FindShortestPath(new ChessKnightWalk.Pos(0, 0, 0), new ChessKnightWalk.Pos(4, 2, 0));
        }

        public class ChessKnightWalk
        {
            public class Pos
            {
                public Tuple<int, int> coords;
                public int steps { get; set; }

                public Pos(int x, int y, int s)
                {
                    coords = new Tuple<int, int>(x, y);
                    steps = s;
                }
            }

            public readonly static int[,] fixedPos = { { -2, -1 }, { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };

            private static void GetNextPos(Tuple<int, int> curr, Dictionary<Tuple<int, int>, Pos> visited, Queue<Tuple<int, int>> path, int step)
            {
                for (int i = 0; i <= 8; ++i)
                {
                    int x = ChessKnightWalk.fixedPos[i, 0];
                    int y = ChessKnightWalk.fixedPos[i, 1];
                    var t = new Tuple<int, int>(curr.Item1 + x, curr.Item2 + y);
                    if (t.Item1 >= 0 && t.Item1 <= 8 && t.Item2 >= 0 && t.Item2 <= 8 && !visited.ContainsKey(t))
                    {
                        visited.Add(t, new Pos(t.Item1, t.Item2, step));
                        path.Enqueue(t);
                    }
                }
            }
            public static int FindShortestPath(Pos start, Pos end)
            {
                var visited = new Dictionary<Tuple<int, int>, Pos>();
                var path = new Queue<Tuple<int, int>>();
                path.Enqueue(start.coords);
                visited.Add(start.coords, start);
                while (path.Count > 0)
                {
                    var curr = path.Dequeue();
                    if (curr.Equals(end.coords))
                    {
                        return visited[curr].steps;
                    }

                    var step = visited[curr].steps;
                    GetNextPos(curr, visited, path, ++step);
                }

                return -1;
            }
        }
    }
}
