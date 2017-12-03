using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode295.Find_Median_from_Data_Stream
{
	//https://leetcode.com/problems/find-median-from-data-stream/description/
	//time exceeds because SortedDictionary is not exactly a heap.
	class Program
	{
		static void Main(string[] args)
		{
			var m = new MedianFinder();
			double r = 0;
			//m.AddNum(1);
			//r = m.FindMedian();
			//m.AddNum(2);
			//r = m.FindMedian();
			//m.AddNum(3);
			//r = m.FindMedian();
			//m.AddNum(4);
			//r = m.FindMedian();
			m.AddNum(12);
			r = m.FindMedian();
			m.AddNum(10);
			r = m.FindMedian();
			m.AddNum(13);
			r = m.FindMedian();
			m.AddNum(11);
			r = m.FindMedian();
			m.AddNum(5);
			r = m.FindMedian();
			m.AddNum(15);
			r = m.FindMedian();
			m.AddNum(1);
			r = m.FindMedian();
			m.AddNum(11);
			r = m.FindMedian();
			m.AddNum(6);
			r = m.FindMedian();
			m.AddNum(17);
			r = m.FindMedian();
			m.AddNum(14);
			r = m.FindMedian();
			m.AddNum(8);
			r = m.FindMedian();
			m.AddNum(17);
			r = m.FindMedian();
			m.AddNum(6);
			r = m.FindMedian();
			m.AddNum(4);
			r = m.FindMedian();
			m.AddNum(16);
			r = m.FindMedian();
			m.AddNum(8);
			r = m.FindMedian();
			m.AddNum(10);
			r = m.FindMedian();
			m.AddNum(2);
			r = m.FindMedian();
			m.AddNum(12);
			r = m.FindMedian();
			m.AddNum(0);
			r = m.FindMedian();
		}
	}
	public class MedianItem
	{
		public int size;
		public SortedDictionary<int, int> items = new SortedDictionary<int, int>();
		public void AddNum(int num)
		{
			this.size++;
			var count = 0;
			if (this.items.TryGetValue(num, out count))
			{
				this.items[num] = ++count;
			}
			else this.items.Add(num, 1);
		}
		public int RemoveMax()
		{
			return RemoveItem(true);
		}
		public int RemoveMin()
		{
			return RemoveItem(false);
		}
		public int Min()
		{
			return this.items.First().Key;
		}

		public int Max()
		{
			return this.items.Last().Key;
		}
		private int RemoveItem(bool isMax)
		{
			var ret = isMax ? this.items.LastOrDefault() : this.items.FirstOrDefault();
			this.size--;
			if (--this.items[ret.Key] == 0)
			{
				this.items.Remove(ret.Key);
			}
			return ret.Key;
		}
	}
	public class MedianFinder
	{
		private MedianItem maxItems = new MedianItem();
		private MedianItem minItems = new MedianItem();

		public void AddNum(int num)
		{
			if (maxItems.size == 0 || num >= maxItems.Max())
			{
				maxItems.AddNum(num);
			}
			else
			{
				if (num > maxItems.Min())
				{
					var min = maxItems.RemoveMin();
					maxItems.AddNum(num);
					minItems.AddNum(min);
				}
				else
					minItems.AddNum(num);
			}

			if (maxItems.size > minItems.size + 1)
			{
				var min = maxItems.RemoveMin();
				minItems.AddNum(min);
			}
			if (minItems.size > maxItems.size)
			{
				var max = minItems.RemoveMax();
				maxItems.AddNum(max);
			}
		}

		public double FindMedian()
		{
			if (maxItems.size > minItems.size)
			{
				return maxItems.Min();
			}

			return (double)(maxItems.Min() + minItems.Max()) / 2;
		}
	}

	//simple, just using sort, also time exceeds even before the solution above.
	//public class MedianFinder
	//{
	//	private List<int> items = new List<int>();
	//	private int count = 0;
	//	public void AddNum(int num)
	//	{
	//		count++;
	//		items.Add(num);
	//		items.Sort();
	//	}

	//	public double FindMedian()
	//	{
	//		var mid = (items.Count - 1)/2;
	//		if ((items.Count - 1) % 2 == 0) return items[mid];
	//		return (double)(items[mid] + items[mid + 1]) / 2;
	//	}
	//}
}
