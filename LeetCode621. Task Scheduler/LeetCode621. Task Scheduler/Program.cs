using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode621.Task_Scheduler
{
	class Program
	{
		//https://leetcode.com/problems/task-scheduler/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B'},50);
			//var r = s.LeastInterval(new char[] { 'A', 'B', 'B', 'B','C','D' }, 2);
		}
		public class Solution
		{
			public int LeastInterval(char[] tasks, int n)
			{
				var hist = new int[26];
				foreach (var c in tasks)
				{
					hist[c - 'A']++;
				}

				hist = hist.OrderByDescending(x => x).ToArray();
				var time = 0;
				while (hist[0] != 0)
				{
					var i = 0;
					while (i <= n)
					{
						if (hist[0] == 0) break;
						if (i < 26 && hist[i] > 0)
						{
							hist[i]--;
						}
						++i;
						++time;
					}
					hist = hist.OrderByDescending(x => x).ToArray();
				}
				return time;
			}
		}
	}
}
