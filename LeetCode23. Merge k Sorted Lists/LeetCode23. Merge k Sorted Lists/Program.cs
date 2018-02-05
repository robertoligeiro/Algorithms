using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode23.Merge_k_Sorted_Lists
{
	class Program
	{
		//https://leetcode.com/problems/merge-k-sorted-lists/description/
		static void Main(string[] args)
		{
		}

		public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int x) { val = x; }
		}

		public class Solution
		{
			public ListNode MergeKLists(ListNode[] lists)
			{
				var pqueue = new List<Tuple<ListNode, int>>();
				for(int i = 0; i < lists.Length;++i)
				{
					if (lists[i] != null)
					{
						pqueue.Add(new Tuple<ListNode, int>(lists[i], i));
						lists[i] = lists[i].next;
					}
				}
				var resp = new ListNode(-1);
				var it = resp;
				pqueue.Sort(SortLists);
				while (pqueue.Count > 0)
				{
					var curr = pqueue[0];
					pqueue.RemoveAt(0);
					it.next = new ListNode(curr.Item1.val);
					it = it.next;
					if (lists[curr.Item2] != null)
					{
						pqueue.Add(new Tuple<ListNode, int>(lists[curr.Item2], curr.Item2));
						lists[curr.Item2] = lists[curr.Item2].next;
						pqueue.Sort(SortLists);
					}
					
				}
				return resp.next;
			}

			private int SortLists(Tuple<ListNode, int> a, Tuple<ListNode, int> b)
			{
				return a.Item1.val.CompareTo(b.Item1.val);
			}
		}
	}
}
