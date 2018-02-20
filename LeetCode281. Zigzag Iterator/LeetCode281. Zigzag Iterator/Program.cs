using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode281.Zigzag_Iterator
{
	class Program
	{
		//https://leetcode.com/problems/zigzag-iterator/
		static void Main(string[] args)
		{
		}

		public class ZigzagIterator
		{
			private int indexV1;
			private int indexV2;
			private IList<int> v1;
			private IList<int> v2;
			private Queue<int> items = new Queue<int>();
			private void AddToQueue()
			{
				if (indexV1 < v1.Count) items.Enqueue(v1[indexV1++]);
				if (indexV2 < v2.Count) items.Enqueue(v2[indexV2++]);
			}
			public ZigzagIterator(IList<int> v1, IList<int> v2)
			{
				this.v1 = v1;
				this.v2 = v2;
				AddToQueue();
			}

			public bool HasNext()
			{
				return items.Count > 0;
			}

			public int Next()
			{
				AddToQueue();
				return items.Dequeue();
			}
		}
	}
}
