using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionGenerateAllSubsetsOfK
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetSubsets(5, 3);
        }

        public static List<List<int>> GetSubsets(int n, int k)
        {
            var resp = new List<List<int>>();
            var parc = new List<int>();
            var values = Enumerable.Range(1, n).ToList();
            GetSubsets(values, resp, parc, k, 0);
            return resp;
        }

        public static void GetSubsets(List<int> values, List<List<int>> resp, List<int> parc, int k, int pos)
        {
            if (parc.Count == k)
            {
                resp.Add(new List<int>(parc));
                return;
            }

            for (int i = pos; i < values.Count; ++i)
            {
                parc.Add(values[i]);
                GetSubsets(values, resp, parc, k, i + 1);
                parc.RemoveAt(parc.Count - 1);
            }
        }
    }
}
