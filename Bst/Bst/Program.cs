using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bst
{
	class Program
	{
		static void Main(string[] args)
		{
			var bst = new Bst();
			var root = bst.Insert(5);
			bst.Insert(3);
			bst.Insert(1);
			bst.Insert(4);
			bst.Insert(6);
			root = bst.Delete(5);
			root = bst.Delete(3);
			root = bst.Delete(1);
			root = bst.Delete(6);
			root = bst.Delete(4);
		}

		public class Node
		{
			public int val;
			public Node left;
			public Node right;
		}
		public class Bst
		{
			private Node root;
			public Node Insert(int key)
			{
				if (root == null)
				{
					root = new Node() { val = key };
					return root;
				}
				return InsertRec(this.root, key);
			}

			private Node InsertRec(Node n, int key)
			{
				if (n == null)
				{
					return new Node() { val = key };
				}
				if (n.val > key)
				{
					n.left = InsertRec(n.left, key);
				}
				else
				{
					n.right = InsertRec(n.right, key);
				}
				return n;
			}

			public Node Delete(int key)
			{
				if (root == null) return null;
				var n = DeleteRec(this.root, key);
				if (n != root) root = n;
				return n;
			}

			private Node DeleteRec(Node n, int k)
			{
				if (n == null) return null;
				if (n.val > k)
				{
					n.left = DeleteRec(n.left, k);
					return n;
				}
				else if (n.val < k)
				{
					n.right = DeleteRec(n.right, k);
					return n;
				}

				if (n.left == null && n.right == null) return null;
				if (n.left == null || n.right == null)
				{
					return n.left == null ? n.right : n.left;
				}

				var replaceNode = n.right;
				while (replaceNode.left != null)
				{
					replaceNode = replaceNode.left;
				}
				DeleteRec(n, replaceNode.val);
				n.val = replaceNode.val;
				return n;
			}
		}
	}
}
