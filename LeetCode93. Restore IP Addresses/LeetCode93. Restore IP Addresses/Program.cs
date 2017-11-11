using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode93.Restore_IP_Addresses
{
	class Program
	{
		//https://leetcode.com/submissions/detail/127707480/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.RestoreIpAddresses("25525511135");
		}
		public class Solution
		{
			public IList<string> RestoreIpAddresses(string s)
			{
				var resp = new List<string>();
				var parc = new List<string>();
				RestoreIpAddresses(s, resp, parc);
				return resp;
			}

			private void RestoreIpAddresses(string s, List<string> resp, List<string> parc)
			{
				if (parc.Count == 4)
				{
					if (string.IsNullOrEmpty(s))
					{
						resp.Add(string.Join(".", parc));
					}
					return;
				}

				for (int i = 0; i <= 2 && i < s.Length; ++i)
				{
					if (i == 1 && s[0] == '0') return;
					var sub = s.Substring(0, i + 1);
					int val = int.Parse(sub);
					if (val <= 255)
					{
						parc.Add(sub);
						RestoreIpAddresses(s.Substring(i + 1), resp, parc);
						parc.RemoveAt(parc.Count - 1);
					}
				}
			}
		}
	}
}
