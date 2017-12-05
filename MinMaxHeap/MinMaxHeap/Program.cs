using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxHeap
{
	class Program
	{
		static void Main(string[] args)
		{
			var heap = new PriorityQueue(false);
			heap.AddNum(5);
			heap.AddNum(15);
			heap.AddNum(51);
			heap.AddNum(2);
			heap.AddNum(4);
			heap.AddNum(6);
			while (heap.items.Count > 0)
			{
				var he = heap.GetTop();
			}
		}
		public class PriorityQueue
		{
			public List<int> items = new List<int>();
			public bool isMin;
			public PriorityQueue(bool isMin)
			{
				this.isMin = isMin;
			}
			public void AddNum(int num)
			{
				items.Add(num);
				var curr = items.Count - 1;
				var parent = curr / 2;
				while (parent >= 0)
				{
					if (curr != 0 && curr % 2 == 0) parent--;
					if ((this.isMin && items[curr] < items[parent]) ||
						(!this.isMin && items[curr] > items[parent]))
					{
						var t = items[curr];
						items[curr] = items[parent];
						items[parent] = t;
						curr = parent;
						parent = curr / 2;
					}
					else break;
				}
			}
			public int GetTop()
			{
				var ret = items[0];
				items[0] = items[items.Count - 1];
				items.RemoveAt(items.Count - 1);
				var parent = 0;
				var curr = 1;
				while (curr < items.Count)
				{
					if (curr + 1 < items.Count &&
						((this.isMin && items[curr] > items[curr + 1]) ||
						(!this.isMin && items[curr] < items[curr + 1])))
					{
						++curr;
					}
					if ((this.isMin && items[curr] < items[parent]) ||
						(!this.isMin && items[curr] > items[parent]))
					{
						var t = items[parent];
						items[parent] = items[curr];
						items[curr] = t;
						parent = curr;
						curr = (curr * 2) + 1;
					}
					else break;
				}
				return ret;
			}
		}
	}
}
