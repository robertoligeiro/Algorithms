using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesStringDecompositionsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetDecompositions("amanaplanacanal", new List<string>() { "can", "apl", "ana" }, 3); //resp 4
            var r1 = GetDecompositions("amanaplanacanacanapl", new List<string>() { "can", "apl", "ana" }, 3);
        }

        public static List<int> GetDecompositions(string sentence, List<string> words, int pSize)
        {
            var hist = new Dictionary<string, int>();
            GetHistogram(words, hist);
            var resp = new List<int>();
            for (int i = 0; i < sentence.Length; ++i)
            {
                if (i + pSize >= sentence.Length) break;
                var sub = sentence.Substring(i, pSize);
                if (hist.ContainsKey(sub) && ContainAllSubs(sentence, i, new Dictionary<string, int>(hist), pSize))
                {
                    resp.Add(i);
                }
            }

            return resp;
        }

        public static bool ContainAllSubs(string sentence, int l, Dictionary<string, int> hist, int pSize)
        {
            for (int i = l; i < sentence.Length; i+=pSize)
            {
                if (i + pSize > sentence.Length) break;
                var sub = sentence.Substring(i, pSize);
                var count = 0;
                if (hist.TryGetValue(sub, out count))
                {
                    if (--count == 0) hist.Remove(sub);
                    else hist[sub] = count;
                    if (hist.Count == 0) return true;
                }
                else return false;
            }

            return false;
        }
        public static void GetHistogram(List<string> words, Dictionary<string, int> hist)
        {
            foreach (var w in words)
            {
                var count = 0;
                if (hist.TryGetValue(w, out count))
                {
                    hist[w] = ++count;
                }
                else hist.Add(w, 1);
            }
        }
   }
}
