using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode670.Maximum_Swap
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MaximumSwap(9789);
		}

		public class Solution
		{
			public int MaximumSwap(int num)
			{
				var aNum = num.ToString().ToArray();
				var last = new int[10];
				for (int i = 0; i < aNum.Length; ++i)
				{
					last[aNum[i] - '0'] = i;
				}

				for (int i = 0; i < aNum.Length; ++i)
				{
					for (int j = 9; j > aNum[i] - '0'; --j)
					{
						if (i < last[j])
						{
							var t = aNum[i];
							aNum[i] = aNum[last[j]];
							aNum[last[j]] = t;
							return int.Parse(new string(aNum));
						}
					}
				}
				return num;
			}
		}
	}
}
