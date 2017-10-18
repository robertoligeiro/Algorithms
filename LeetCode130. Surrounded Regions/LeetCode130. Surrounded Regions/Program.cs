using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode130.Surrounded_Regions
{
	class Program
	{
		// Solution using BSF.
		// Easier way could be:
		// from here: https://leetcode.com/problems/surrounded-regions/discuss/
		//First, check the four border of the matrix.If there is a element is
		//'O', alter it and all its neighbor 'O' elements to '1'.
		//Then ,alter all the 'O' to 'X'
		//At last, alter all the '1' to 'O'
		static void Main(string[] args)
		{
			//var board = new char[,] {
			//	{ 'X', 'X', 'X', 'X'},
			//	{ 'X', 'O', 'O', 'X'},
			//	{ 'X', 'X', 'O', 'X'},
			//	{ 'X', 'O', 'X', 'X'}
			//};
			//var board = new char[,] {
			//	{ 'X', 'X', 'X'},
			//	{ 'X', 'O', 'X'},
			//	{ 'X', 'X', 'X'}
			//};
			var board = new char[,] {
				{'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
				{ 'X','X','X','X','X','X','X','X','X','O','O','O','X','X','X','X','X','X','X','X'},
				{ 'X','X','X','X','X','O','O','O','X','O','X','O','X','X','X','X','X','X','X','X'},
				{ 'X','X','X','X','X','O','X','O','X','O','X','O','O','O','X','X','X','X','X','X'},
				{ 'X','X','X','X','X','O','X','O','O','O','X','X','X','X','X','X','X','X','X','X'},
				{ 'X','X','X','X','X','O','X','X','X','X','X','X','X','X','X','X','X','X','X','X'}
			};
			var s = new Solution();
			s.Solve(board);
		}
		public class Solution
		{
			public void Solve(char[,] board)
			{
				for (var r = 1; r <= board.GetLength(0) - 2; ++r)
				{
					for (var c = 1; c <= board.GetLength(1) - 2; ++c)
					{
						if(board[r,c] == 'O')
							CheckAndTurn(board, new Tuple<int, int>(r, c));
					}
				}
			}
			private void CheckAndTurn(char[,] board, Tuple<int,int> curr)
			{
				var v = new HashSet<Tuple<int, int>>();
				var q = new Queue<Tuple<int, int>>();
				q.Enqueue(curr);
				var path = new List<Tuple<int, int>>();
				var maxRow = board.GetLength(0) - 1;
				var maxCol = board.GetLength(1) - 1;
				while (q.Count > 0)
				{
					curr = q.Dequeue();
					v.Add(curr);
					if (board[curr.Item1, curr.Item2] == 'O')
					{
						if (
							curr.Item1 == 0 ||
							curr.Item1 == maxRow ||
							curr.Item2 == 0 ||
							curr.Item2 == maxCol)
						{
							return;
						}
						GetAdj(q, v, curr, maxRow, maxCol);
						path.Add(curr);
					}
				}
				foreach (var t in path) board[t.Item1, t.Item2] = 'X';
			}

			private void GetAdj(Queue<Tuple<int, int>> q, HashSet<Tuple<int, int>> v, Tuple<int, int> curr, int maxRow, int maxCol)
			{
				var left = new Tuple<int, int>(curr.Item1, curr.Item2 - 1);
				var right = new Tuple<int, int>(curr.Item1, curr.Item2 + 1);
				var down = new Tuple<int, int>(curr.Item1 + 1, curr.Item2);
				var up = new Tuple<int, int>(curr.Item1 - 1, curr.Item2);
				if (left.Item2 >= 0 && v.Add(left)) q.Enqueue(left);
				if (right.Item2 <= maxCol && v.Add(right)) q.Enqueue(right);
				if (up.Item1 >= 0 && v.Add(up)) q.Enqueue(up);
				if (down.Item1 <= maxRow && v.Add(down)) q.Enqueue(down);
			}
		}
	}
}
