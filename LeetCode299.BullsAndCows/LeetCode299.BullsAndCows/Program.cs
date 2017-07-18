using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode299.BullsAndCows
{
    class Program
    {
        //https://leetcode.com/problems/bulls-and-cows/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GetHint("1807", "7810"); //1A3B
            r = s.GetHint("1123", "0111"); //1A1B
            r = s.GetHint("1121", "0111"); // 2A1B
        }

        public class Solution
        {
            public string GetHint(string secret, string guess)
            {
                var newScret = string.Empty;
                var newGuess = string.Empty;
                var bulls = CountBulls(secret, guess, out newScret, out newGuess);
                var cows = CountCows(newScret, newGuess);
                return bulls + "A" + cows + "B";
            }

            private int CountCows(string secret, string guess)
            {
                var s = new Dictionary<char, int>();
                for (int i = 0; i < secret.Length; ++i)
                {
                    var count = 0;
                    if (s.TryGetValue(secret[i], out count))
                    {
                        s[secret[i]] = ++count;
                    }
                    else
                    {
                        s.Add(secret[i], 1);
                    }
                }
                var resp = 0;
                foreach (var c in guess)
                {
                    var count = 0;
                    if (s.TryGetValue(c, out count))
                    {
                        if (count > 0) resp++;
                        s[c] = --count;
                    }
                }
                return resp;
            }
            private int CountBulls(string secret, string guess, out string newSecret, out string newGuess)
            {
                var newSecretSb = new StringBuilder();
                var newGuessSb = new StringBuilder();
                var count = 0;
                for (int i = 0; i < secret.Length; ++i)
                {
                    if (secret[i] != guess[i])
                    {
                        newGuessSb.Append(guess[i]);
                        newSecretSb.Append(secret[i]);
                    }
                    else count++;
                }
                newGuess = newGuessSb.ToString();
                newSecret = newSecretSb.ToString();
                return count;
            }
        }
    }
}
