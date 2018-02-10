using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode721.Accounts_Merge
{
	class Program
	{
		//https://leetcode.com/problems/accounts-merge/description/
		static void Main(string[] args)
		{
			var a = '_';
			var b = '0';
			var ll = new List<string>() { "john00@mail.com", "john_newyork@mail.com", "a@abc" };
			ll.Sort(StringComparer.Ordinal);
			var l = new List<IList<string>>() {
				new List<string>(){ "John", "johnsmith@mail.com", "john_newyork@mail.com" },
				new List<string>() { "John", "johnsmith@mail.com", "john00@mail.com" },
				new List<string>() { "Mary", "mary@mail.com" },
				new List<string>() { "John", "johnnybravo@mail.com" } };

			var s = new Solution();
			var r = s.AccountsMerge(l);
		}
		//public static int comp(string a, string b)
		//{
		//	return a.ToArray().
		//}
		public class Solution
		{
			public class Node
			{
				public string name;
				public HashSet<string> emails = new HashSet<string>();
			}
			public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
			{
				var resp = new List<IList<string>>();
				if (accounts == null) return resp;

				var emailToNode = new Dictionary<string, List<Node>>();
				var rootNodes = new List<Node>();
				foreach (var l in accounts)
				{
					var n = new Node() { name = l.FirstOrDefault() };
					for (int i = 1; i < l.Count; ++i)
					{
						n.emails.Add(l[i]);
						List<Node> nodes;
						if (emailToNode.TryGetValue(l[i], out nodes)) nodes.Add(n);
						else emailToNode.Add(l[i], new List<Node>() { n });
					}
					rootNodes.Add(n);
				}

				var visited = new HashSet<Node>();
				foreach(var curr in rootNodes)
				{
					if (visited.Add(curr))
					{
						var l = new HashSet<string>() { curr.name };
						DfsEmails(curr, emailToNode, visited, l);
						var respItem = l.ToList();
						respItem.Sort(StringComparer.Ordinal);
						resp.Add(respItem);
					}
				}
				return resp;
			}

			private void DfsEmails(Node n, Dictionary<string, List<Node>> emailToNode, HashSet<Node> visited, HashSet<string> resp)
			{
				foreach (var child in n.emails)
				{
					if (resp.Add(child))
					{
						foreach (var childNode in emailToNode[child])
						{
							if (visited.Add(childNode))
							{
								DfsEmails(childNode, emailToNode, visited, resp);
							}
						}
					}
				}
			}
		}
	}
}
