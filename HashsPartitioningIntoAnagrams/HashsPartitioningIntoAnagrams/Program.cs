using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashsPartitioningIntoAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<string>() { "debitcard", "elvis", "silent", "badcredit", "lives", "freedom", "listen", "levis", "money" };
            var r = PartitionIntoAnagrams(l);
        }

        public static List<List<string>> PartitionIntoAnagrams(List<string> a)
        {
            var anagrams = new Dictionary<string, List<string>>();
            foreach (var s in a)
            {
                var sortedS = new string(s.OrderBy(c => c).ToArray());
                List<string> l;
                if (anagrams.TryGetValue(sortedS, out l))
                {
                    l.Add(s);
                }
                else
                {
                    anagrams.Add(sortedS, new List<string>() { s });
                }
            }
            var resp = new List<List<string>>();
            foreach (var v in anagrams.Values)
            {
                if (v.Count > 1)
                {
                    resp.Add(v);
                }
            }
            return resp;
        }
    }
}
