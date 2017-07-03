using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode524.LongestWordinDicthroughDeleting
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindLongestWord("abpcplea", new List<string>() { "ale", "apple", "monkey", "plea", "cplea" });
            //var r = s.FindLongestWord("wsmzffsupzgauxwokahurhhikapmqitytvcgrfpavbxbmmzdhnrazartkzrnsmoovmiofmilihynvqlmwcihkfskwozyjlnpkgdkayioieztjswgwckmuqnhbvsfoevdynyejihombjppgdgjbqtlauoapqldkuhfbynopisrjsdelsfspzcknfwuwdcgnaxpevwodoegzeisyrlrfqqavfziermslnlclbaejzqglzjzmuprpksjpqgnohjjrpdlofruutojzfmianxsbzfeuabhgeflyhjnyugcnhteicsvjajludwizklkkosrpvhhrgkzctzwcghpxnbsmkxfydkvfevyewqnzniofhsriadsoxjmsswgpiabcbpdjjuffnbvoiwotrbvylmnryckpnyemzkiofwdnpnbhkapsktrkkkakxetvdpfkdlwqhfjyhvlxgywavtmezbgpobhikrnebmevthlzgajyrmnbougmrirsxi", 
            //    new List<string>() { "nbmxgkduynigvzuyblwjepn" });
            
        }

        public class Solution
        {
            public string FindLongestWord(string s, IList<string> d)
            {
                var m = new Dictionary<char, List<int>>();
                for (int i = 0; i < s.Length; ++i)
                {
                    List<int> l;
                    if (m.TryGetValue(s[i], out l))
                    {
                        l.Add(i);
                    }
                    else
                    {
                        m.Add(s[i], new List<int>() { i });
                    }
                }

                var maxSoFar = string.Empty;
                foreach (var w in d)
                {
                    if (w.Length >= maxSoFar.Length && m.ContainsKey(w[0]))
                    {
                        if (w.Length == maxSoFar.Length && string.Compare(w, maxSoFar) > 0)
                        {
                            continue;
                        }
                            var newDictionary = m.ToDictionary(entry => entry.Key,
                                               entry => new List<int>(entry.Value));
                        if (CanAdd(w, newDictionary))
                        {
                             maxSoFar = w;
                        }
                    }
                }

                return maxSoFar;
            }

            public bool CanAdd(string s, Dictionary<char, List<int>> m)
            {
                var lastIndex = -1;
                foreach (var c in s)
                {
                    var indexes = new List<int>();
                    if (!m.TryGetValue(c, out indexes)) return false;
                    if (indexes.Count == 0) return false;
                    if (lastIndex == -1)
                    {
                        lastIndex = indexes[0];
                        indexes.RemoveAt(0);
                    }
                    else
                    {
                        while (indexes.Count > 0 && indexes.FirstOrDefault() < lastIndex)
                        {
                            indexes.RemoveAt(0);
                        }
                        if (indexes.Count == 0) return false;
                        lastIndex = indexes.FirstOrDefault();
                        indexes.RemoveAt(0);
                    }
                }
                return true;
            }
        }

        public class Solution2
        {
            public string FindLongestWord(string s, IList<string> d)
            {
                var m = new Dictionary<char, List<int>>();
                for (int i = 0; i < s.Length; ++i)
                {
                    List<int> l;
                    if (m.TryGetValue(s[i], out l))
                    {
                        l.Add(i);
                    }
                    else
                    {
                        m.Add(s[i], new List<int>() { i });
                    }
                }

                var maxSoFar = string.Empty;
                foreach (var w in d)
                {
                    if (m.ContainsKey(w[0]))
                    {
                        var newDictionary = m.ToDictionary(entry => entry.Key,
                                               entry => new List<int>(entry.Value));
                        if (CanAdd(w, newDictionary))
                        {
                            if (w.Length > maxSoFar.Length)
                            {
                                maxSoFar = w;
                            }
                            else
                            {
                                if (w.Length == maxSoFar.Length)
                                {
                                    if (string.Compare(w, maxSoFar) < 0)
                                    {
                                        maxSoFar = w;
                                    }
                                }
                            }
                        }
                    }
                }

                return maxSoFar;
            }

            public bool CanAdd(string s, Dictionary<char, List<int>> m)
            {
                return CanAdd(s, m, 0, 0);
            }
            public bool CanAdd(string s, Dictionary<char, List<int>> m, int p, int min)
            {
                if (p == s.Length) return true;

                List<int> l;
                if (!m.TryGetValue(s[p], out l)) return false;
                var newMin = -1;
                foreach (var i in l)
                {
                    if (i >= min)
                    {
                        newMin = i;
                        break;
                    }
                }
                if (newMin == -1)
                {
                    return false;
                }
                l.Remove(newMin);
                return CanAdd(s, m, p + 1, newMin);
            }
        }
    }
}
