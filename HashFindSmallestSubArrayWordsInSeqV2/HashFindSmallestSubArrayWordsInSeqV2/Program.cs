using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFindSmallestSubArrayWordsInSeqV2
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
            r = FindSmallest(words, term); // resp 0,3
        }

        public static Tuple<int, int> FindSmallest(List<string> words, List<string> term)
        {
            var termMap = new Dictionary<string, int>();
            for (var i = 0; i < term.Count; ++i)
            {
                termMap.Add(term[i], i);
            }
            var indexes = Enumerable.Repeat(-1, term.Count).ToArray();
            var distances = new int[term.Count];
            var minSoFarTuple = new Tuple<int, int>(-1,-1);
            var minSoFar = int.MaxValue;
            var found = false;

            for (int i = 0; i < words.Count; ++i)
            {
                var index = 0;
                if (termMap.TryGetValue(words[i], out index))
                {
                    if (!found && index > 0) continue;
                    if (index == 0)
                    {
                        indexes[index] = i;
                        distances[index] = 0;
                        found = true;
                    }
                    else
                    {
                        if (indexes[index - 1] != -1)
                        {
                            indexes[index] = i;
                            distances[index] = i - indexes[index - 1] + distances[index - 1];
                        }

                        if (index == term.Count - 1)
                        {
                            if (minSoFarTuple.Item1 == -1 || minSoFar > distances[index])
                            {
                                minSoFarTuple = new Tuple<int, int>(indexes.Last() - distances.Last(), indexes.Last());
                                minSoFar = minSoFarTuple.Item2 - minSoFarTuple.Item1;
                            }
                        }
                    }
                }
            }

            return minSoFarTuple;
        }
    }
}
