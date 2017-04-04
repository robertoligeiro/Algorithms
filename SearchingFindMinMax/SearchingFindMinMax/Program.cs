using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindMinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindMinMax(new List<int>() { 3, 2, 5, 1, 2, 4 });
        }

        public static Tuple<int, int> FindMinMax(List<int> a)
        {
            var globalMinMax = GetMinMax(a[0], a[1]);
            for (int i = 2; i + 1 < a.Count; i += 2)
            {
                var localMinMax = GetMinMax(a[i], a[i + 1]);
                globalMinMax = new Tuple<int, int>(Math.Min(globalMinMax.Item1, localMinMax.Item1), Math.Max(globalMinMax.Item2, localMinMax.Item2));
            }
            if (a.Count % 2 == 0)
            {
                globalMinMax = new Tuple<int, int>(Math.Min(globalMinMax.Item1, a.Last()), Math.Max(globalMinMax.Item2, a.Last()));
            }

            return globalMinMax;
        }

        public static Tuple<int, int> GetMinMax(int a, int b)
        {
            if (a < b) return new Tuple<int, int>(a, b);
            return new Tuple<int, int>(b, a);
        }
    }
}
