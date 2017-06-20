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
            var found = new Dictionary<string,int>();
            var l = 0;
            var r = 0;
            var resp = new Tuple<int, int>(-1,-1);
            var notDone = true;
            while (notDone)
            {
                notDone = false;
                while (l < r)
                {
                    if (resp.Item1 == -1 || r - l < resp.Item2 - resp.Item1)
                    {
                        resp = new Tuple<int, int>(l, r - 1);
                    }

                    var count = 0;
                    if (found.TryGetValue(words[l], out count))
                    {
                        if (--count == 0) found.Remove(words[l]);
                        else found[words[l]] = count;
                    }

                    l++;
                    if (found.Count < term.Count) break;
                }

                while (r < words.Count && found.Count < term.Count)
                {
                    if (term.Contains(words[r]))
                    {
                        var count = 0;
                        if (found.TryGetValue(words[r], out count))
                        {
                            found[words[r]] = ++count;
                        }
                        else found.Add(words[r], 1);
                    }
                    r++;
                    notDone = true;
                }
            }

            return resp;
        }
    }
}
