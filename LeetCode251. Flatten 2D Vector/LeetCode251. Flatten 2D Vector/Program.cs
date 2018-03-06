using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode251.Flatten_2D_Vector
{
	class Program
	{
		//https://leetcode.com/problems/flatten-2d-vector/description/
		static void Main(string[] args)
		{
		}
		public class Vector2D
		{
			private Stack<IList<int>> items;
			private int index = 0;
			public Vector2D(IList<IList<int>> vec2d)
			{
				items = new Stack<IList<int>>();
				for (int i = vec2d.Count - 1; i >= 0; --i)
				{
					if (vec2d[i].Count > 0)
					{
						items.Push(vec2d[i]);
					}
				}
			}

			public bool HasNext()
			{
				return items.Count > 0;
			}

			public int Next()
			{
				if (this.HasNext())
				{
					var ret = items.Peek()[index++];
					if (items.Peek().Count == index)
					{
						items.Pop();
						index = 0;
					}
					return ret;
				}
				return -1;
			}
		}
	}
}
