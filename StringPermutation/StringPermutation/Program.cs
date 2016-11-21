using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var rrr = StringCombine.DoStringCombine("aabc");

            var rr = ArrayPermut.DoPermut(new int[]{1,2,3,4,5});

            var r = StringPermut.DoStringPermut("aabc");
        }

        public static class StringCombine
        {
            public static List<string> DoStringCombine(string s)
            {
                var parc = new char[s.Count()];
                var hist = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    int t;
                    if (hist.TryGetValue(c, out t))
                    {
                        hist[c] = ++t;
                    }
                    else hist.Add(c, 1);
                }

                var ret = new List<string>();
                CombineRecurse(hist, ret, parc, 0, 0);
                return ret;
            }

            private static void CombineRecurse(Dictionary<char, int> hist, List<string> ret, char[] parc, int pos, int index)
            {
                var nHist = new Dictionary<char, int>(hist);
                for (int i = pos; i < nHist.Count; ++i)
                {
                    var e = nHist.ElementAt(i);
                    if (e.Value != 0)
                    {
                        nHist[e.Key]--;
                        parc[index] = e.Key;
                        ret.Add(new string(parc));
                        CombineRecurse(nHist, ret, parc, i, index + 1);
                        parc[index] = ' ';
                        //nHist[e.Key]++;
                    }
                }
            }
        }


    public class ArrayPermut
        {
            public static List<int[]> DoPermut(int[] a)
            {
                var parc = new int[a.Count()];
                var hist = new List<int>(a.Count());
                for(int i = 0; i < a.Count(); ++i)
                {
                    hist.Add(1);
                }

                var ret = new List<int[]>();
                PerRec(a, hist, parc, ret, 0);
                return ret;
            }

            private static void PerRec(int[] s, List<int> h, int[] parc, List<int[]> resp, int pos)
            {
                if (pos == parc.Count())
                {
                    var c = new List<int>(parc);
                    resp.Add(c.ToArray());
                    return;
                }

                var nHist = new List<int>(h);

                for (int i = 0; i < nHist.Count(); ++i)
                {
                    if (nHist[i] != 0)
                    {
                        nHist[i]--;
                        parc[pos] = s[i];
                        PerRec(s, nHist, parc, resp, pos + 1);
                        nHist[i]++;
                    }
                }
            }
        }


        public static class StringPermut
        {
            public static List<string> DoStringPermut(string s)
            {
                var parc = new char[s.Count()];
                var hist = new Dictionary<char, int>();
                foreach (var c in s)
                {
                    int t;
                    if (hist.TryGetValue(c, out t))
                    {
                        hist[c] = ++t;
                    }
                    else hist.Add(c, 1);
                }

                var ret = new List<string>();
                StringPermutRecurse(hist, ret, parc, 0);
                return ret;
            }

            private static void StringPermutRecurse(Dictionary<char, int> hist, List<string> ret, char[] parc, int pos)
            {
                if (pos == parc.Count())
                {
                    ret.Add(new string(parc));
                    return;
                }

                var nHist = new Dictionary<char, int>(hist);
                for (int i = 0; i < nHist.Count; ++i)
                {
                    var e = nHist.ElementAt(i);
                    if (e.Value != 0)
                    {
                        nHist[e.Key]--;
                        parc[pos] = e.Key;
                        StringPermutRecurse(nHist, ret, parc, pos + 1);
                        nHist[e.Key]++;
                    }
                }
            }
        }
    }
}
