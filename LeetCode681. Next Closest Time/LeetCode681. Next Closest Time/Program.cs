using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode681.Next_Closest_Time
{
	class Program
	{
		//https://leetcode.com/problems/next-closest-time/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.NextClosestTime("19:34");
			//var r = s.NextClosestTime("23:59");
			//var r = s.NextClosestTime("01:59");
		}
		//easier but less efficient - leetcode accepts.
		//public class Solution
		//{
		//	public string NextClosestTime(string time)
		//	{
		//		var tTime = DateTime.Parse(time, System.Globalization.CultureInfo.CurrentCulture);
		//		var h = new HashSet<char>();
		//		foreach (var c in time) h.Add(c);
		//		while (true)
		//		{
		//			tTime = tTime.AddMinutes(1);
		//			var haveAll = true;
		//			time = tTime.ToString("HH:mm");
		//			foreach (var c in time)
		//			{
		//				if (!h.Contains(c))
		//				{
		//					haveAll = false;
		//					break;
		//				} 
		//			}
		//			if (haveAll) return time;
		//		}
		//		return string.Empty;
		//	}
		//}
		
		//more efficient.
		public class Solution
		{
			public string NextClosestTime(string time)
			{
				var iTime = new List<int>();
				var hourAndMinutes = time.Split(':');
				foreach (var c in time)
				{
					if (c != ':') iTime.Add(c - '0');
				}
				iTime.Sort();
				for (int i = 1; i >= 0; --i)
				{
					for (int j = 1; j >= 0; --j)
					{
						var digArray = hourAndMinutes[i].ToArray();
						var dig = hourAndMinutes[i][j] - '0';
						var index = iTime.LastIndexOf(dig) + 1;
						if (index < iTime.Count)
						{
							digArray[j] = (char)(iTime[index] + '0');
							if (j == 0)
							{
								digArray[1] = (char)(iTime[0] + '0');
							}
							if (i == 1)
							{
								if (int.Parse(new string(digArray)) <= 59)
									return hourAndMinutes[0] + ":" + new string(digArray);
							}
							else if (int.Parse(new string(digArray)) <= 24)
							{
								return new string(digArray) + ":" + new string(Enumerable.Repeat((char)(iTime[0] + '0'), 2).ToArray());
							}
						}
					}
				}
				var minDig = new string(Enumerable.Repeat((char)(iTime[0] + '0'), 2).ToArray());
				return minDig + ":" + minDig;
			}
		}
	}
}
