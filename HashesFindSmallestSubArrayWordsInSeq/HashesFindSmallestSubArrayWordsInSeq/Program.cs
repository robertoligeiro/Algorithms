using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesFindSmallestSubArrayWordsInSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>()
            {
                "apple", "banana", "apple",
                "cat", "banana", "dog",
                "apple", "banana", "cat",
            };
            var term = new List<string>() { "apple", "banana", "cat" };
            var r = FindSmallest(words, term); // resp 6,8

            words = new List<string>()
            {
                "apple", "banana", "apple",
                "cat", "apple", "banana",
                "dog", "banana", "cat",
            };
            r = FindSmallest(words, term); // resp 6,8
        }

        public static Tuple<int, int> FindSmallest(List<string> words, List<string> term)
        {
            var resp = new Tuple<int, int>(-1, -1);
            var minSoFar = int.MaxValue;
            var termIndexes = new Dictionary<string, int>();
            int i = 0;
            foreach (var w in term)
            {
                termIndexes.Add(w, i++);
            }

            var lastOcurrenceIndex = Enumerable.Repeat(-1, term.Count).ToArray();
            var minSizeToIndex = Enumerable.Repeat(-1, term.Count).ToArray();
            i = 0;
            foreach (var w in words)
            {
                var index = 0;
                if (termIndexes.TryGetValue(w, out index))
                {
                    if (index == 0)
                    {
                        lastOcurrenceIndex[0] = i;
                        minSizeToIndex[0] = 1;
                    }
                    else
                    {
                        if (minSizeToIndex[index - 1] != -1)
                        {
                            var localDist = i - lastOcurrenceIndex[index - 1];
                            minSizeToIndex[index] = minSizeToIndex[index - 1] + localDist;
                        }
                        lastOcurrenceIndex[index] = i;
                    }

                    if (index == term.Count - 1 && minSizeToIndex[index] != -1)
                    {
                        if (minSizeToIndex[index] < minSoFar)
                        {
                            minSoFar = minSizeToIndex[index];
                            resp = new Tuple<int, int>(i + 1 - minSoFar, i);
                        }
                    }
                }
                ++i;
            }

            return resp;
        }
    }
}
