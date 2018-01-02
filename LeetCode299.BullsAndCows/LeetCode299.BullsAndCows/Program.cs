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

			r = s.GetHint("11", "10"); // 1A0B

			r = s.GetHint("1123", "0111"); //1A1B

			r = s.GetHint("1121", "0111"); // 2A1B
		}

		public class Solution
		{
			public string GetHint(string secret, string guess)
			{
				var hist = new Dictionary<char, int>();
				var bullsIndex = new HashSet<int>();
				var bulls = 0;
				for (int i = 0; i < secret.Length; ++i)
				{
					if (secret[i] == guess[i])
					{
						bulls++;
						bullsIndex.Add(i);
					} 
					else
					{
						var count = 0;
						if (hist.TryGetValue(secret[i], out count))
						{
							hist[secret[i]] = ++count;
						}
						else hist.Add(secret[i], 1);
					}
				}

				var cows = 0;
				for (int i = 0; i < guess.Length; ++i)
				{
					if (bullsIndex.Contains(i)) continue;
					var count = 0;
					if (hist.TryGetValue(guess[i], out count))
					{
						cows++;
						if (--count == 0) hist.Remove(guess[i]);
						else hist[guess[i]] = count;
					}
				}
				return bulls + "A" + cows + "B";
			}
		}
    }
}
