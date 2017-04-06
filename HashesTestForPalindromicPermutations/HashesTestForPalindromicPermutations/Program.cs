using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesTestForPalindromicPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = HasPalindrome("level"); //true
            b = HasPalindrome("edified"); //true
            b = HasPalindrome("foaraboofob"); //true
            b = HasPalindrome("roatort"); //true
            b = HasPalindrome("efdified"); //true
            b = HasPalindrome("edifierd"); //false
        }

        public static bool HasPalindrome(string s)
        {
            var charCount = new Dictionary<char, int>();
            foreach (var c in s)
            {
                var count = 0;
                if (charCount.TryGetValue(c, out count))
                {
                    count++;
                    charCount[c] = count;
                }
                else
                {
                    charCount.Add(c, 1);
                }
            }
            var countOdds = 0;
            foreach (var i in charCount.Values)
            {
                if (i % 2 != 0 && countOdds++ == 1) return false;
            }
            return true;
        }
    }
}
