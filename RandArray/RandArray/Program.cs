using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandArray
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new ShuffleArray(new int[] { 1, 2, 3, 4, 5 });
			var r = s.Shuffle();
			var t = s.Reset();
			var w = s.Shuffle();
			w[0] = 100;
			var y = s.Reset();
			y[0] = 200;
		}

		public class ShuffleArray
		{
			private int[] arr;
			private int[] shuffled;
			public ShuffleArray(int[] a)
			{
				this.arr = a;
			}
			public int[] Reset()
			{
				return this.arr;
			}
			public int[] Shuffle()
			{
				if (this.shuffled != null) return this.shuffled;
				this.shuffled = new int[this.arr.Length];
				Array.Copy(this.arr, this.shuffled, this.arr.Length);
				var rand = new Random();
				for (int i = 0; i < this.shuffled.Length; ++i)
				{
					var to = rand.Next(this.shuffled.Length - i) + i;
					var temp = this.shuffled[to];
					this.shuffled[to] = this.shuffled[i];
					this.shuffled[i] = temp;
				}
				return this.shuffled;
			}
		}
	}
}
