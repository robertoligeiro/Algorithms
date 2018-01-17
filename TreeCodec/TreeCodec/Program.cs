using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCodec
{
	class Program
	{
		//https://leetcode.com/problems/serialize-and-deserialize-binary-tree/description/
		static void Main(string[] args)
		{
			var tString = "5,3,1,n,n,4,n,n,6,n,n";
			var t = TreeCodec.TreeDeserialize(tString);

			var r = TreeCodec.TreeSerialize(t);
		}

		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}

		public class TreeCodec
		{
			public static string TreeSerialize(TreeNode n)
			{
				var t = new List<string>();
				TreeInOrder(n, t);
				return string.Join(",", t);
			}
			private static void TreeInOrder(TreeNode n, List<string> t)
			{
				if (n == null)
				{
					t.Add("n");
					return;
				}
				t.Add(n.val.ToString());
				TreeInOrder(n.left, t);
				TreeInOrder(n.right, t);
			}

			public static TreeNode TreeDeserialize(string s)
			{
				var q = new Queue<string>(s.Split(','));
				return TreeDeserialize(q);
			}
			private static TreeNode TreeDeserialize(Queue<string> q)
			{
				var v = q.Dequeue();
				if (v == "n") return null;
				var n = new TreeNode(int.Parse(v));
				n.left = TreeDeserialize(q);
				n.right = TreeDeserialize(q);
				return n;
			}
		}
	}
}
