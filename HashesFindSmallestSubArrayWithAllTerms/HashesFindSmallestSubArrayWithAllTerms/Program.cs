using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesFindSmallestSubArrayWithAllTerms
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetSmallestSubArray( //resp 8,10
                new List<string>()
                { "apple", "banana", "apple", "apple", "dog", "cat",
                    "apple", "dog", "banana", "apple", "cat", "dog" }, new HashSet<string>() { "banana","cat"});

            r = GetSmallestSubArray( //resp 9,10
                new List<string>()
                { "apple", "dog", "banana", "apple", "apple", "dog", "cat",
                    "apple", "dog", "banana", "apple", "cat", "dog" }, new HashSet<string>() { "apple", "banana" });

            r = GetSmallestSubArray( //resp -1,-1
                new List<string>()
                { "apple", "dog", "banana", "apple", "apple", "dog", "cat",
                    "apple", "dog", "banana", "apple", "cat", "dog" }, new HashSet<string>() { "banana", "donots" });

            r = GetSmallestSubArray( //resp 9,9
                new List<string>()
                { "apple", "dog", "banana", "apple", "apple", "dog", "cat",
                    "apple", "dog", "banana", "apple", "cat", "dog" }, new HashSet<string>() { "banana" });
        }

        public static Tuple<int, int> GetSmallestSubArray(List<string> words, HashSet<string> searchTerm)
        {
            var localSearch = new HashSet<string>();
            Tuple<int, int> resp = new Tuple<int, int>(-1,-1);
            var minSoFar = int.MaxValue;
            var start = 0;
            var end = 0;
            var index = 0;
            foreach (var w in words)
            {
                if (searchTerm.Contains(w))
                {
                    localSearch.Add(w);
                    if (localSearch.Count == 1)
                    {
                        start = index;
                    }
                    if (localSearch.Count == searchTerm.Count)
                    {
                        end = index;
                        var localDist = end - start;
                        if (localDist < minSoFar)
                        {
                            resp = new Tuple<int, int>(start, end);
                        }
                        start = index;
                        end = 0;
                        localSearch = new HashSet<string>() { w };
                    }
                }
                index++;
            }

            return resp;
        }
    }
}
