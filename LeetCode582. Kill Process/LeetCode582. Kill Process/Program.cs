using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode582.Kill_Process
{
	//https://leetcode.com/problems/kill-process/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public class ProcessTreeNode
			{
				public int pid;
				public List<ProcessTreeNode> children;
				public ProcessTreeNode(int pid)
				{
					this.pid = pid;
					children = new List<ProcessTreeNode>();
				}
			}
			public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
			{
				var m = new Dictionary<int, ProcessTreeNode>();
				for (int i = 0; i < pid.Count; ++i)
				{
					ProcessTreeNode child = null;
					if (!m.TryGetValue(pid[i], out child))
					{
						child = new ProcessTreeNode(pid[i]);
						m.Add(pid[i], child);
					}

					ProcessTreeNode parent = null;
					if (!m.TryGetValue(ppid[i], out parent))
					{
						parent = new ProcessTreeNode(ppid[i]);
						m.Add(ppid[i], parent);
					}

					parent.children.Add(child);
				}

				var q = new Queue<ProcessTreeNode>();
				q.Enqueue(m[kill]);
				var resp = new List<int>();
				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					resp.Add(curr.pid);
					foreach (var c in curr.children)
					{
						q.Enqueue(c);
					}
				}

				return resp;
			}
		}
	}
}
