using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode346.Moving_Average_from_Data_Stream
{
	class Program
	{
		//https://leetcode.com/explore/interview/card/bloomberg/74/design/423/
		static void Main(string[] args)
		{
			var movingAvr = new MovingAverage(3);
			var n = movingAvr.Next(1);
			n = movingAvr.Next(2);
			n = movingAvr.Next(2);
			n = movingAvr.Next(2);

		}
		public class MovingAverage
		{
			private Queue<int> data = new Queue<int>();
			private int size;
			private int sum;

			/** Initialize your data structure here. */
			public MovingAverage(int size)
			{
				this.size = size;
			}

			public double Next(int val)
			{
				var sub = 0;
				if (data.Count >= this.size)
				{
					sub = data.Dequeue();
				}
				data.Enqueue(val);
				this.sum += (val - sub);
				return this.sum / (double)data.Count;
			}
		}
	}
}
