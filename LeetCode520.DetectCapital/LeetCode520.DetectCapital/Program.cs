using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode520.DetectCapital
{
    //https://leetcode.com/problems/detect-capital/#/descriptions
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public bool DetectCapitalUse(string word)
            {
                var firstCap = false;
                var secondCap = false;
                for (var i = 0; i < word.Length; ++i)
                {
                    if (i == 0 && char.IsUpper(word[i])) firstCap = true;
                    else if (i == 1 && char.IsUpper(word[i]))
                    {
                        if (!firstCap) return false;
                        secondCap = true;
                    }
                    else if (firstCap && secondCap && char.IsLower(word[i])) return false;
                    else if (firstCap && !secondCap && char.IsUpper(word[i])) return false;
                    else if (!firstCap && char.IsUpper(word[i])) return false;
                }

                return true;
            }
        }
    }
}
