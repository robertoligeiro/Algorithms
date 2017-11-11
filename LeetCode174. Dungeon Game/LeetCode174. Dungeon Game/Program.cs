using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode174.Dungeon_Game
{
	class Program
	{
		static void Main(string[] args)
		{
			//var g = new int[,] { { -2, -3, 3 }, { -5, -10, 1 }, { 10, 30, -5 } };
			var g = new int[,] { { -3, 5 }};
			var s = new Solution();
			var r = s.CalculateMinimumHP(g);
		}

		public class Solution
		{
			public int CalculateMinimumHP(int[,] dungeon)
			{
				var memo = new Dictionary<Tuple<int, int>, int>();
				var ret = CalculateMinimumHP(dungeon, new Tuple<int, int>(0, 0), memo);
				if (ret <= 0)
				{
					ret = -ret;
					return ++ret;
				}
				return 0;
			}

			private int CalculateMinimumHP(int[,] dungeon, Tuple<int, int> pos, Dictionary<Tuple<int, int>, int> memo)
			{
				if (pos.Item1 == dungeon.GetLength(0) - 1 && pos.Item2 == dungeon.GetLength(1) - 1)
				{
					return dungeon[pos.Item1, pos.Item2] <= 0? dungeon[pos.Item1, pos.Item2]:0;
				}

				var max = 0;
				if (memo.TryGetValue(pos, out max)) return max;
				var right = int.MinValue;
				if (pos.Item2 + 1 < dungeon.GetLength(1))
				{
					right = CalculateMinimumHP(dungeon, new Tuple<int, int>(pos.Item1, pos.Item2 + 1), memo);
				}
				var down = int.MinValue;
				if (pos.Item1 + 1 < dungeon.GetLength(0))
				{
					down = CalculateMinimumHP(dungeon, new Tuple<int, int>(pos.Item1 + 1, pos.Item2), memo);
				}

				max = Math.Max(right, down);
				if (dungeon[pos.Item1, pos.Item2] < 0)
				{
					max += dungeon[pos.Item1, pos.Item2];
				}
				else
				{
					var diff = dungeon[pos.Item1, pos.Item2] + max;
					max = diff >= 0 ? 0 : diff;
				}
				memo.Add(pos, max);
				return max;
			}
		}
	}
}
