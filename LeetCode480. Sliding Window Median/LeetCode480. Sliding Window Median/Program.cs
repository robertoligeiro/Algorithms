using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode480.Sliding_Window_Median
{
	class Program
	{
		//https://leetcode.com/problems/sliding-window-median/description/
		// it's time exceeding on leetcode, but I'm happy with the solution.
		static void Main(string[] args)
		{
			var m = new Median(3);
			double r = 0;
			m.Add(1);
			r = m.GetMedian();
			m.Add(3);
			r = m.GetMedian();
			m.Add(-1);
			r = m.GetMedian();
			m.Add(-3);
			r = m.GetMedian();

			var s = new Solution();
			var rr = s.MedianSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
		}
		public class Solution
		{
			public double[] MedianSlidingWindow(int[] nums, int k)
			{
				var resp = new List<double>();

				var median = new Median(k);
				var index = 0;
				while (k-- > 0)
				{
					median.Add(nums[index++]);
				}

				resp.Add(median.GetMedian());
				for (; index < nums.Length; ++index)
				{
					median.Add(nums[index]);
					resp.Add(median.GetMedian());
				}
				return resp.ToArray();
			}
		}
		public class ValContainer
		{
			public SortedDictionary<int, int> container;
			public int size;
			public ValContainer()
			{
				this.container = new SortedDictionary<int, int>();
			}

			public void Add(int val)
			{
				this.size++;
				var count = 0;
				if (this.container.TryGetValue(val, out count))
				{
					this.container[val] = ++count;
				}
				else this.container.Add(val, 1);
			}

			public void Remove(int val)
			{
				this.size--;
				var count = 0;
				if (this.container.TryGetValue(val, out count))
				{
					this.container[val] = --count;
					if (count == 0) this.container.Remove(val);
				}
			}
		}
		public class Median
		{
			private int maxSize;
			private ValContainer min;
			private ValContainer max;
			private Queue<int> insertionOrder;
			public Median(int maxSize)
			{
				this.maxSize = maxSize;

				min = new ValContainer();
				max = new ValContainer();
				insertionOrder = new Queue<int>();
			}

			public void Add(int val)
			{
				if (insertionOrder.Count == this.maxSize)
				{
					this.Remove(insertionOrder.Dequeue());
				}

				insertionOrder.Enqueue(val);
				if (this.min.size == 0 || val >= this.min.container.First().Key)
				{
					this.min.Add(val);
				}
				else
				{
					max.Add(val);
				}

				this.RebalanceContainers();
			}

			public double GetMedian()
			{
				if (this.min.size > this.max.size)
				{
					return this.min.container.FirstOrDefault().Key;
				}
				return ((double)this.min.container.FirstOrDefault().Key + (double)this.max.container.LastOrDefault().Key) / 2;
			}
			private void RebalanceContainers()
			{
				if (this.min.size == this.max.size + 2)
				{
					var val = this.min.container.First().Key;
					this.max.Add(val);
					this.min.Remove(val);
				}
				else if (this.max.size == this.min.size + 1)
				{
					var val = this.max.container.Last().Key;
					this.min.Add(val);
					this.max.Remove(val);
				}
			}
			private void Remove(int val)
			{
				if (this.min.container.ContainsKey(val))
				{
					this.min.Remove(val);
				}
				else if (this.max.container.ContainsKey(val))
				{
					this.max.Remove(val);
				}
				RebalanceContainers();
			}
		}
	}
}
