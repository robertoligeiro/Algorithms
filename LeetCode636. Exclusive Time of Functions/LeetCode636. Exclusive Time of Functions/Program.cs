using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode636.Exclusive_Time_of_Functions
{
	class Program
	{
		static void Main(string[] args)
		{
			//var logs = new List<string>() { "0:start:0",
			//								"1:start:2",
			//								"1:end:5",
			//								"0:end:6"};
			var logs = new List<string>() { "0:start:0", "0:start:2", "0:end:5", "0:start:6", "0:end:6", "0:end:7" };
			var s = new Solution();
			var r = s.ExclusiveTime(1, logs);
		}

		public class Solution
		{
			public int[] ExclusiveTime(int n, IList<string> logs)
			{
				var resp = new int[n];
				var s = new Stack<int>();
				int prev = 0;
				foreach (var t in logs)
				{
					var tokens = t.Split(':');
					var id = int.Parse(tokens[0]);
					var status = tokens[1];
					var time = int.Parse(tokens[2]);
					if (status == "start")
					{
						if (s.Count > 0)
						{
							resp[s.Peek()] += time - prev;
						}
						s.Push(id);
						prev = time;
					}
					else
					{
						resp[s.Peek()] += time - prev + 1;
						prev = time + 1;
						s.Pop();
					}
				}
				return resp;
			}
		}
	}
}
