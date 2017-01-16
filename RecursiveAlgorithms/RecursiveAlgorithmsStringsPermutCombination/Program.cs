using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var combination = StringCombination.DoStringCombination("aabc");
            var permutation = StringPermutation.DoStringPermutation("aabc");
        }

        // aabc -> 	AABC, AACB, ABAC, ABCA, ACAB, ACBA, BAAC, BACA, BCAA, CAAB, CABA, CBAA
		// - Add to response every time loop reaches the end.
		// - Do recursion starting from 0 each level.
        class StringPermutation
        {
            private static void DoStringPermutationRec(string input, Dictionary<char, int> hist, List<string> resp, char[] curr, int posWrite)
            {
                if (posWrite == curr.Count())
                {
                    resp.Add(new string(curr));
                    return;
                }
                var localHist = new Dictionary<char,int>(hist);

                for (int i = 0; i < localHist.Count; ++i)
                {
                    if (localHist.ElementAt(i).Value > 0)
                    {
                        curr[posWrite++] = localHist.ElementAt(i).Key;
                        localHist[localHist.ElementAt(i).Key]--;
                        DoStringPermutationRec(input, localHist, resp, curr, posWrite);
                        curr[--posWrite] = ' ';
                        localHist[localHist.ElementAt(i).Key]++;
                    }
                }
            }

            public static List<string> DoStringPermutation(string input)
            {
                var charHist = new Dictionary<char, int>();
                var currString = new char[input.Count()];
                var resp = new List<string>();
                foreach (var c in input)
                {
                    int t;
                    if (charHist.TryGetValue(c, out t))
                    {
                        charHist[c] = ++t;
                    }
                    else
                    {
                        charHist.Add(c, 1);
                    }
                }

                DoStringPermutationRec(input, charHist, resp, currString, 0);
                return resp;
            }
        }

        // AABC -> A, AA, AAB, AABC, AAC, AB, ABC, AC, B, BC, C
		// - Add each iteration to response.
        // - Do recursion starting loop from where recursion previously left.
        class StringCombination
        {
            private static void DoStringCombinationRec(string input, Dictionary<char, int> hist, List<string> resp, char[] curr, int posWrite, int posRead)
            {
                var localHist = new Dictionary<char, int>(hist);

                for (int i = posRead; i < localHist.Count; ++i)
                {
                    if (localHist.ElementAt(i).Value > 0)
                    {
                        curr[posWrite++] = localHist.ElementAt(i).Key;
                        string s = new string(curr);
                        resp.Add(s);
                        localHist[localHist.ElementAt(i).Key]--;
                        DoStringCombinationRec(input, localHist, resp, curr, posWrite, i);
                        curr[--posWrite] = ' ';
                        //localHist[localHist.ElementAt(i).Key]++;
                    }
                }
            }

            public static List<string> DoStringCombination(string input)
            {
                var charHist = new Dictionary<char, int>();
                var currString = new char[input.Count()];
                var resp = new List<string>();
                foreach (var c in input)
                {
                    int t;
                    if (charHist.TryGetValue(c, out t))
                    {
                        charHist[c] = ++t;
                    }
                    else
                    {
                        charHist.Add(c, 1);
                    }
                }

                resp.Add(string.Empty);
                DoStringCombinationRec(input, charHist, resp, currString, 0, 0);
                return resp;
            }
        }
    }
}
