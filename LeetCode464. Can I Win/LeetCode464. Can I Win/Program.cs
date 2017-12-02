using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode464.Can_I_Win
{
	//https://leetcode.com/problems/can-i-win/discuss/
	//not working
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.CanIWin(10, 40);
			//var r = s.CanIWin(4,6);
			var r = s.CanIWin(10, 11);
		}

		public class Solution
		{
			public bool CanIWin(int maxChoosableInteger, int desiredTotal)
			{
				var memo = new Dictionary<Tuple<int,int>, bool>();
				return CanIWin(maxChoosableInteger, desiredTotal, 0, 1, memo);
			}

			public bool CanIWin(int maxChoosableInteger, int desiredTotal, int acc, int player, Dictionary<Tuple<int, int>, bool> memo)
			{
				var resp = false;
				var t = new Tuple<int, int>(player, acc);
				if (memo.TryGetValue(t, out resp)) return resp;

				if (acc + maxChoosableInteger >= desiredTotal) return false;

				for (int i = 1; i <= maxChoosableInteger; ++i)
				{
					var ret = CanIWin(maxChoosableInteger, desiredTotal, acc + i, -player, memo);

					if (!ret && player == 1)
					{
						t = new Tuple<int, int>(player, acc);
						if (!memo.ContainsKey(t)) memo.Add(t, true);
						return player == 1 ? true : false;
					}
				}

				t = new Tuple<int, int>(player, acc);
				if (!memo.ContainsKey(t)) memo.Add(t, false);
				return false;
			}
		}
	}
}
