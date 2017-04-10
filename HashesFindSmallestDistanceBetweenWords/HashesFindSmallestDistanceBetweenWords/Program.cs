using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesFindSmallestDistanceBetweenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindSmallestDistance(new List<string>() { "all", "work", "and", "no", "play", "makes", "for", "no", "work", "no", "fun", "and", "no", "results" });
        }

        public class SmallestDistance
        {
            public int dist = int.MaxValue;
            public int first = -1;
            public int second = -1;
        }

        public static Tuple<int, int> FindSmallestDistance(List<string> words)
        {
            var result = new SmallestDistance();
            var hist = new Dictionary<string, SmallestDistance>();
            int i = 1;
            foreach(var w in words)
            {
                SmallestDistance local;
                if (hist.TryGetValue(w, out local))
                {
                    var localDist = i - local.second;
                    if (result.dist > localDist)
                    {
                        result.dist = localDist;
                        result.first = local.second - 1;
                        result.second = i - 1; 
                    }

                    local.first = local.second;
                    local.second = i;
                    if (localDist < local.dist)
                    {
                        local.dist = localDist;
                    }
                }
                else
                {
                    hist.Add(w, new SmallestDistance() { second = i });
                }
                ++i;
            }

            return new Tuple<int, int>(result.first, result.second);
        }
    }
}
