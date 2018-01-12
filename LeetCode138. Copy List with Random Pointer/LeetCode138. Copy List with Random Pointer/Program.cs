using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode138.Copy_List_with_Random_Pointer
{
	//https://leetcode.com/problems/copy-list-with-random-pointer/description/
	class Program
	{
		static void Main(string[] args)
		{
			var l = new RandomListNode(1) { next = new RandomListNode(2) { next = new RandomListNode(3) } };
			l.random = l.next.next;
			l.next.random = l.next;
			l.next.next.random = l;

			var s = new Solution();
			var r = s.CopyRandomList(l);
		}

  public class RandomListNode {
      public int label;
      public RandomListNode next, random;
      public RandomListNode(int x) { this.label = x; }
  };
		public class Solution
		{
			public RandomListNode CopyRandomList(RandomListNode head)
			{
				if (head == null) return null;

				var curr = head;
				var next = curr.next;
				// 1. create copy attached to original list
				while (curr != null)
				{
					var copyNode = new RandomListNode(curr.label);

					curr.next = copyNode;
					copyNode.next = next;
					curr = next;
					next = next != null? next.next: null;
				}

				//2. assign the random nodes
				curr = head;
				while (curr != null)
				{
					if (curr.random != null)
					{
						curr.next.random = curr.random.next;
					}
					curr = curr.next.next;
				}

				//3. isolate lists
				curr = head;
				next = head.next;
				var ret = next;
				while (curr != null)
				{
					curr.next = next.next;
					curr = next.next;

					next.next = next.next != null ? next.next.next : null;
					next = next.next; 
				}
				return ret;
			}
		}
		public class SolutionNonOptimal
		{
			public RandomListNode CopyRandomList(RandomListNode head)
			{
				var m = new Dictionary<int, RandomListNode>();
				return CopyRandomList(head, m);
			}

			private RandomListNode CopyRandomList(RandomListNode n, Dictionary<int, RandomListNode> m)
			{
				if (n == null) return null;
				RandomListNode c = null;
				if (m.TryGetValue(n.label, out c)) return c;
				c = new RandomListNode(n.label);
				m.Add(n.label, c);
				c.random = CopyRandomList(n.random, m);
				c.next = CopyRandomList(n.next, m);
				return c;
			}
		}
	}
}
