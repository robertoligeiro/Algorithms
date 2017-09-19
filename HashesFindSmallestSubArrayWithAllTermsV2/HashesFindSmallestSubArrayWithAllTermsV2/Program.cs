using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesFindSmallestSubArrayWithAllTermsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetSmallestSubArray(new List<string>() { "banana", "apple", "tea", "car", "car", "banana" }, new HashSet<string>() { "banana","car"});
            var r1 = GetSmallestSubArray(new List<string>() { "banana", "apple", "tea", "car", "car", "banana" }, new HashSet<string>() { "banana", "tea", "car" });
        }
        public static Tuple<int, int> GetSmallestSubArray(List<string> words, HashSet<string> term)
        {
            var min = int.MaxValue;
            var m = new Dictionary<string, int>();
            var i = 0;
            var j = 0;
            var resp1 = -1;
            var resp2 = -1;
            while (j < words.Count)
            {
                while (j < words.Count && m.Count < term.Count)
                {
                    if (term.Contains(words[j]))
                    {
                        var count = 0;
                        if (!m.TryGetValue(words[j], out count))
                        {
                            m.Add(words[j], 1);
                        }
                        else m[words[j]] = ++count;
                    }
                    ++j;
                }
                while (i < j && m.Count == term.Count)
                {
                    var localMin = j - i - 1;
                    if (localMin < min)
                    {
                        resp1 = i;
                        resp2 = j - 1;
                        min = localMin;
                    }
                    var count = 0;
                    if (m.TryGetValue(words[i], out count))
                    {
                        if (--count == 0) m.Remove(words[i]);
                        else m[words[i]] = count;
                    }
                    ++i;
                }
            }
            return new Tuple<int, int>(resp1, resp2);
        }
    }
}
