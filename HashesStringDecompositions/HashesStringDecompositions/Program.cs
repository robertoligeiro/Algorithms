using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesStringDecompositions
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetDecompositions("amanaplanacanal", new List<string>() { "can", "apl", "ana" }, 3);
        }

        public static List<int> GetDecompositions(string sentence, List<string> words, int pSize)
        {
            var hist = new Dictionary<string, int>();
            foreach (var w in words)
            {
                var count = 0;
                if (hist.TryGetValue(w, out count))
                {
                    hist[w] = ++count;
                }
                else
                {
                    hist.Add(w, 1);
                }
            }
            var resp = new List<int>();
            for (int i = 0; i < sentence.Length; ++i)
            {
                if (GetIndex(i, sentence, hist, pSize, words.Count))
                {
                    resp.Add(i);
                }
            }
            return resp;
        }

        public static bool GetIndex(int index,string sentence, Dictionary<string, int> hist, int pSize, int pCount)
        {
            var lHist = new Dictionary<string, int>(hist);
            for (int i = index; i < sentence.Length && i / pSize <= pCount; i += pSize)
            {
                string w = sentence.Substring(i, pSize);
                var count = 0;
                if (lHist.TryGetValue(w, out count))
                {
                    if (--count > 0)
                    {
                        lHist[w] = count;
                    }
                    else
                    {
                        lHist.Remove(w);
                    }
                }
                else return false;
            }
            return lHist.Count == 0;
        } 
    }
}
