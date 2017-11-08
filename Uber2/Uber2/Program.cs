using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber2
{
	class Program
	{
		static void Main(string[] args)
		{
			var quadTree = new QuadTree();
			quadTree.Add(1,1);
			quadTree.Add(1, 6);
			quadTree.Add(6, 1);
			quadTree.Add(6, 6);
			quadTree.Add(7, 7);
		}

		public class QuadTreeNode
		{
			public int startX;
			public int startY;
			public int endX;
			public int endY;
			public Tuple<int, int> value;
			public List<QuadTreeNode> childs = new List<QuadTreeNode>();
		}
		public class QuadTree
		{
			public int endX = 10;
			public int endY = 10;
			public QuadTreeNode root = new QuadTreeNode() { startX = 0, startY = 0, endX = 10, endY = 10};

			public void Add(int x, int y)
			{
				Add(x,y, this.root);
			}

			private void Add(int x, int y, QuadTreeNode q)
			{
				if (q.value == null && q.childs.Count == 0)
				{
					q.value = new Tuple<int, int>(x, y);
				}
				else
				{
					var nodeId = 0;
					if (q.childs.Count == 0)
					{
						var halfX = (q.endX - q.startX) / 2;
						var halfY = (q.endY - q.startY) / 2;
						var q0 = new QuadTreeNode() { startX = q.startX, startY = q.startY, endX = halfX, endY = halfY };
						var q1 = new QuadTreeNode() { startX = q.startX, startY = halfY, endX = halfX, endY = q.endY };
						var q2 = new QuadTreeNode() { startX = halfX, startY = q.startY, endX = q.endX, endY = halfY };
						var q3 = new QuadTreeNode() { startX = halfX, startY = halfY, endX = q.endX, endY = q.endY };
						q.childs.Add(q0);
						q.childs.Add(q1);
						q.childs.Add(q2);
						q.childs.Add(q3);
						nodeId = FindQuadNode(q.value.Item1, q.value.Item2, q);
						q.childs[nodeId].value = new Tuple<int, int>(q.value.Item1, q.value.Item2);
						q.value = null;
					}
					nodeId = FindQuadNode(x, y, q);
					Add(x, y, q.childs[nodeId]);
				}
			}

			private int FindQuadNode(int x, int y, QuadTreeNode q)
			{
				var halfX = (q.endX - q.startX) / 2;
				var halfY = (q.endY - q.startY) / 2;
				if (x <= halfX && y <= halfY) return 0;
				if (x <= halfX && y > halfY) return 1;
				if (x > halfX && y <= halfY) return 2;
				if (x > halfX && y > halfY) return 3;
				return -1;
			}
		}
	}
}
