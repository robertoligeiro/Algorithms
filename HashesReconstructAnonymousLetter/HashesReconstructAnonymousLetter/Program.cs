using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesReconstructAnonymousLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            var b0 = ReconstructLetter("roberto bonitao", "rrroberto bbonitterereeaaoo");
            var b1 = ReconstructLetter("roberto bonitao", "rrroberto bbonierereeaaoo");
        }

        public static bool ReconstructLetter(string l, string m)
        {
            var countChar = new Dictionary<char, int>();
            foreach (var c in m)
            {
                var count = 0;
                if (countChar.TryGetValue(c, out count))
                {
                    count++;
                    countChar[c] = count;
                }
                else
                {
                    countChar.Add(c, 1);
                }
            }
            foreach(var c in l)
            {
                var count = 0;
                if (countChar.TryGetValue(c, out count))
                {
                    if (--count == -1) return false;
                    countChar[c] = count;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
