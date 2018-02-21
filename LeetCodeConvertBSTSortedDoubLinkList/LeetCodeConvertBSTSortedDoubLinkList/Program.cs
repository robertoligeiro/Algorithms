using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConvertBSTSortedDoubLinkList
{
	class Program
	{
		//https://leetcode.com/explore/interview/card/facebook/52/trees-and-graphs/544/
		static void Main(string[] args)
		{
			var t = new Node(2) { right = new Node(3) };

			var s = new Solution();
			var r = s.TreeToDoublyList(t);
		}
		public class Node
		{
			public int val;
			public Node left;
			public Node right;
			public Node(int x) { val = x; }
		}

		public class Solution
		{
			private Node head;
			private Node last;
			public Node TreeToDoublyList(Node root)
			{
				TreeToDoublyListHelper(root);
				if (head != null)
				{
					head.left = last;
					last.right = head;
				}
				return head;
			}

			private void TreeToDoublyListHelper(Node n)
			{
				if (n == null) return;
				TreeToDoublyListHelper(n.left);
				if (head == null)
				{
					head = n;
					last = n;
				}
				else
				{
					n.left = last;
					last.right = n;
					last = n;
				}

				TreeToDoublyListHelper(n.right);
			}
		}
	}
}
