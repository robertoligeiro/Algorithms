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
			var s = new Solution();
			var r = s.DetectCapitalUse("USA");
			r = s.DetectCapitalUse("Usa");
			r = s.DetectCapitalUse("USa");
			r = s.DetectCapitalUse("uSa");
			r = s.DetectCapitalUse("usa");
		}
		public class Solution
		{
			public bool DetectCapitalUse(string word)
			{
				if (string.IsNullOrWhiteSpace(word)) return true;
				var allCaps = char.IsUpper(word[0]);
				for (int i = 1; i < word.Length; ++i)
				{
					if(allCaps && char.IsLower(word[i]))
					{
						if (i == 1) allCaps = false;
						else return false;
					}
					if (!allCaps && char.IsUpper(word[i])) return false;
				}
				return true;
			}
		}

		//public class Solution
		//{
		//    public bool DetectCapitalUse(string word)
		//    {
		//        var firstCap = false;
		//        var secondCap = false;
		//        for (var i = 0; i < word.Length; ++i)
		//        {
		//            if (i == 0 && char.IsUpper(word[i])) firstCap = true;
		//            else if (i == 1 && char.IsUpper(word[i]))
		//            {
		//                if (!firstCap) return false;
		//                secondCap = true;
		//            }
		//            else if (firstCap && secondCap && char.IsLower(word[i])) return false;
		//            else if (firstCap && !secondCap && char.IsUpper(word[i])) return false;
		//            else if (!firstCap && char.IsUpper(word[i])) return false;
		//        }

		//        return true;
		//    }
		//}
	}
}
