using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsWordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = WordLadder(new HashSet<string>() { "wot", "cot", "hot", "dot", "dog", "lot", "log", "cat" }, "log", "cat");
        }

        public class Candidate
        {
            public string word;
            public int dist;
        }
        public static int WordLadder(HashSet<string> dictionary, string from, string to)
        {
            var alpa = "abcdefghklmnopqrstuvxywz";
            var q = new Queue<Candidate>();
            q.Enqueue(new Candidate() { word = from, dist = 0 });
            dictionary.Remove(from);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                if (curr.word == to) return curr.dist;
                for (int i = 0; i < curr.word.Length; ++i)
                {
                    foreach (var c in alpa)
                    {
                        if (curr.word[i] != c)
                        {
                            var s = curr.word.ToCharArray();
                            s[i] = c;
                            var candidateWord = new string(s);
                            if (dictionary.Remove(candidateWord))
                            {
                                q.Enqueue(new Candidate() { word = candidateWord, dist = curr.dist + 1 });
                            }
                        }
                    }
                }
            }

            return -1;
        }
    }
}
