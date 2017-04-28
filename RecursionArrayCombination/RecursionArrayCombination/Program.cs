using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionArrayCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = ArrayComb(new List<int>() { 0, 1, 2 });
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
            var localM = new Dictionary<int, int>(m);
            var localParc = new List<int>(parc);
            for (int i = pos; i < m.Count; ++i)
            {
                if (m.ElementAt(i).Value > 0)
                {
                    localParc.Add(m.ElementAt(i).Key);
                    localM[localM.ElementAt(i).Key]--;
                    ArrayComb(localM, r, localParc, i);
                    localParc.RemoveAt(localParc.Count - 1);
                }
            }
        }
    }
}
