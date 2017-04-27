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
            var r = PermutArray(new List<int>() { 2, 3, 5, 7 });
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

            var localM = new Dictionary<int, int>(m);
            var localP = new List<int>(p);
            for (int i = 0; i < localM.Count; ++i)
            {
                if (localM.ElementAt(i).Value > 0)
                {
                    localM[localM.ElementAt(i).Key]--;
                    localP.Add(localM.ElementAt(i).Key);
                    PermutArray(a, localM, r, localP);
                    localM[localM.ElementAt(i).Key]++;
                    localP.RemoveAt(localP.Count - 1);
                }
            }
        }
    }
}
