using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode79.Word_Search
{
	//https://leetcode.com/problems/word-search/description/
	class Program
	{
		static void Main(string[] args)
		{
			var b = new char[,] {{'A','B','C','E'},
								{'S','F','C','S'},
								{'A','D','E','E'}};
			var s = new Solution();
			var r = s.Exist(b, "ABCCED");
		}
		public class Solution
		{
			public bool Exist(char[,] board, string word)
			{
				if (string.IsNullOrWhiteSpace(word)) return false;
				for (int row = 0; row < board.GetLength(0); ++row)
				{
					for (int col = 0; col < board.GetLength(1); ++col)
					{
						if (board[row, col] == word[0])
						{
							var p = new Tuple<int, int>(row, col);
							if (Exist(board, word, 1, p, new HashSet<Tuple<int, int>>() { p })) return true;
						}
					}
				}
				return false;
			}

			private bool Exist(char[,] board, string word, int index, Tuple<int, int> pos, HashSet<Tuple<int, int>> visited)
			{
				if (index == word.Length) return true;

				var adj = GetAdj(board, pos);
				foreach (var p in adj)
				{
					if (board[p.Item1, p.Item2] == word[index] && visited.Add(p))
					{
						if (Exist(board, word, index + 1, p, visited)) return true;
						visited.Remove(p);
					}
				}
				return false;
			}

			private List<Tuple<int, int>> GetAdj(char[,] board, Tuple<int, int> pos)
			{
				var resp = new List<Tuple<int, int>>();

				if (pos.Item1 - 1 >= 0)
				{
					resp.Add(new Tuple<int, int>(pos.Item1 - 1, pos.Item2));
				}
				if (pos.Item1 + 1 < board.GetLength(0))
				{
					resp.Add(new Tuple<int, int>(pos.Item1 + 1, pos.Item2));
				}
				if (pos.Item2 - 1 >= 0)
				{
					resp.Add(new Tuple<int, int>(pos.Item1, pos.Item2 - 1));
				}
				if (pos.Item2 + 1 < board.GetLength(1))
				{
					resp.Add(new Tuple<int, int>(pos.Item1, pos.Item2 + 1));
				}
				return resp;
			}
		}
	}
}
