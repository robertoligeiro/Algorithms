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
            var r = GetSubsets(new List<int>() { 1, 2, 3, 4 });
        }

        public static List<List<int>> GetSubsets(List<int> a)
        {
            var resp = new List<List<int>>();
            var parc = new List<int>();
            GetSubsets(a, resp, parc, 0);
            return resp;
        }
        public static void GetSubsets(List<int> a, List<List<int>> resp, List<int> parc, int start)
        {
            resp.Add(new List<int>(parc));
            for (int i = start; i < a.Count; ++i)
            {
                parc.Add(a[i]);
                GetSubsets(a, resp, parc, i + 1);
                parc.RemoveAt(parc.Count - 1);
            }
        }
    }
}
