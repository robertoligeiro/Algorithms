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

			//m.AddNum(12);
			//r = m.FindMedian();
			//m.AddNum(10);
			//r = m.FindMedian();
			//m.AddNum(13);
			//r = m.FindMedian();
			//m.AddNum(11);
			//r = m.FindMedian();
			//m.AddNum(5);
			//r = m.FindMedian();
			//m.AddNum(15);
			//r = m.FindMedian();
			//m.AddNum(1);
			//r = m.FindMedian();
			//m.AddNum(11);
			//r = m.FindMedian();
			//m.AddNum(6);
			//r = m.FindMedian();
			//m.AddNum(17);
			//r = m.FindMedian();
			//m.AddNum(14);
			//r = m.FindMedian();
			//m.AddNum(8);
			//r = m.FindMedian();
			//m.AddNum(17);
			//r = m.FindMedian();
			//m.AddNum(6);
			//r = m.FindMedian();
			//m.AddNum(4);
			//r = m.FindMedian();
			//m.AddNum(16);
			//r = m.FindMedian();
			//m.AddNum(8);
			//r = m.FindMedian();
			//m.AddNum(10);
			//r = m.FindMedian();
			//m.AddNum(2);
			//r = m.FindMedian();
			//m.AddNum(12);
			//r = m.FindMedian();
			//m.AddNum(0);
			//r = m.FindMedian();

			m.AddNum(78);
			m.AddNum(14);
			m.AddNum(50);
			m.AddNum(20);
			m.AddNum(13);
			m.AddNum(9);
			m.AddNum(25);
			m.AddNum(8);
			m.AddNum(13);
			m.AddNum(37);
			m.AddNum(29);
			m.AddNum(33);
			m.AddNum(55);
			m.AddNum(52);
			m.AddNum(6);
			m.AddNum(17);
			m.AddNum(65);
			m.AddNum(23);
			m.AddNum(74);
			m.AddNum(43);
			m.AddNum(5);
			m.AddNum(29);
			m.AddNum(29);
			m.AddNum(72);
			m.AddNum(7);
			m.AddNum(13);
			m.AddNum(56);
			m.AddNum(21);
			m.AddNum(31);
			m.AddNum(66);
			m.AddNum(69);
			m.AddNum(69);
			m.AddNum(74);
			m.AddNum(12);
			m.AddNum(77);
			m.AddNum(23);
			m.AddNum(10);
			m.AddNum(6);
			m.AddNum(27);
			m.AddNum(63);
			m.AddNum(77);
			m.AddNum(21);
			m.AddNum(40);
			m.AddNum(10);
			m.AddNum(19);
			m.AddNum(59);
			m.AddNum(35);
			m.AddNum(40);
			m.AddNum(44);
			m.AddNum(4);
			m.AddNum(15);
			m.AddNum(29);
			m.AddNum(63);
			m.AddNum(27);
			m.AddNum(46);
			m.AddNum(56);
			m.AddNum(0);
			m.AddNum(60);
			m.AddNum(72);
			m.AddNum(35);
			m.AddNum(54);
			m.AddNum(50);
			m.AddNum(14);
			m.AddNum(29);
			m.AddNum(62);
			m.AddNum(24);
			m.AddNum(18);
			m.AddNum(79);
			m.AddNum(16);
			m.AddNum(19);
			m.AddNum(8);
			m.AddNum(77);
			m.AddNum(10);
			m.AddNum(21);
			m.AddNum(66);
			m.AddNum(42);
			m.AddNum(76);
			m.AddNum(14);
			m.AddNum(58);
			m.AddNum(20);
			m.AddNum(0);
		}
	}
	public class MedianFinder
	{
		private LinkedList<int> items = new LinkedList<int>();

		public void AddNum(int num)
		{
			if (items.Count == 0 || num < items.First.Value)
			{
				items.AddFirst(num);
			}
			else if (num > items.Last.Value)
			{
				items.AddLast(num);
			}
			else
			{
				var l = 0;
				var r = items.Count - 1;
				while (l <= r)
				{
					var mid = l + (r - l) / 2;
					if (items.ElementAt(mid) <= num)
					{
						l = mid + 1;
					}
					else r = mid - 1;
				}

				var el = items.Find(items.ElementAt(r));
				var val = items.ElementAt(r);

				for (; el.Next != null && el.Value == el.Next.Value;)
				{
					el = el.Next;
				}
				items.AddAfter(el, num);

				//for (var it = items.First; it != null; it = it.Next)
				//{
				//	if (it.Value >= num)
				//	{
				//		items.AddBefore(it, num);
				//		break;
				//	}
				//}
			}
		}

		public double FindMedian()
		{
			var mid = items.Count / 2;
			if (items.Count % 2 != 0)
			{
				return items.ElementAt(mid);
			}
			return (double)(items.ElementAt(mid) + items.ElementAt(mid - 1)) / 2;
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
	public class MedianFinder2
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
}
