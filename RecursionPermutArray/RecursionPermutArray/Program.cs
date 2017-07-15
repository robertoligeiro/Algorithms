using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPermutArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = PermutArray(new List<int>() { 1,2,3 });
            r = PermutArray(new List<int>() { 1,2,2 });
            r = PermutArray(new List<int>() { 2, 3, 5, 7 });
        }

        public static List<List<int>> PermutArray(List<int> a)
        {
            var m = new Dictionary<int, int>();
            foreach (var i in a)
            {
                var count = 0;
                if (m.TryGetValue(i, out count))
                {
                    m[i] = ++count;
                }
                else m.Add(i, 1);
            }

            var r = new List<List<int>>();
            var p = new List<int>();
            PermutArray(a, m, r, p);
            return r;
        }

        public static void PermutArray(List<int> a, Dictionary<int, int> m, List<List<int>> r, List<int> p)
        {
            if (p.Count == a.Count)
            {
                r.Add(new List<int> (p));
                return;
            }

            for (int i = 0; i < m.Count; ++i)
            {
                if (m.ElementAt(i).Value > 0)
                {
                    m[m.ElementAt(i).Key]--;
                    p.Add(m.ElementAt(i).Key);
                    PermutArray(a, m, r, p);
                    m[m.ElementAt(i).Key]++;
                    p.RemoveAt(p.Count - 1);
                }
            }
        }
    }
}
