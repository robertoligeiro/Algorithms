using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPowerSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = ArrayComb(new List<int>() { 1, 2, 3, 4 });
            r = ArrayComb(new List<int>() { 1, 1, 2 });
        }

        public static List<List<int>> ArrayComb(List<int> a)
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
            var resp = new List<List<int>>();
            var parc = new List<int>();
            ArrayComb(m, resp, parc, 0);
            return resp;
        }

        public static void ArrayComb(Dictionary<int, int> m, List<List<int>> r, List<int> parc, int pos)
        {
            r.Add(new List<int>(parc));
            if (pos == m.Count) return;
            for (int i = pos; i < m.Count; ++i)
            {
                if (m.ElementAt(i).Value > 0)
                {
                    parc.Add(m.ElementAt(i).Key);
                    m[m.ElementAt(i).Key]--;
                    ArrayComb(m, r, parc, i);
                    parc.RemoveAt(parc.Count - 1);
                    m[m.ElementAt(i).Key]++;
                }
            }
        }
    }
}
