using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode289.GameofLife
{
    class Program
    {
        //https://leetcode.com/problems/game-of-life/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var b = new int[,] { { 1, 1 }, { 1, 0 } };
            s.GameOfLife(b);
        }
        public class Solution
        {
            public void GameOfLife(int[,] board)
            {
                var toOne = new List<Tuple<int, int>>();
                var toZero = new List<Tuple<int, int>>();
                for (int row = 0; row < board.GetLength(0); ++row)
                {
                    for (int col = 0; col < board.GetLength(1); ++col)
                    {
                        var neighborsCount = GetCountNeighbors(board, row, col, 1);
                        if (board[row, col] == 0)
                        {
                            if (neighborsCount == 3) toOne.Add(new Tuple<int, int>(row, col));
                        }
                        if (board[row, col] == 1)
                        {
                            if (neighborsCount <= 1 || neighborsCount > 3) toZero.Add(new Tuple<int, int>(row, col));
                        }
                    }
                }

                foreach (var t in toZero)
                {
                    board[t.Item1, t.Item2] = 0;
                }
                foreach (var t in toOne)
                {
                    board[t.Item1, t.Item2] = 1;
                }
            }
            public int GetCountNeighbors(int[,] board, int row, int col, int neighbor)
            {
                var rowPlusOne = row + 1;
                var rowMinusOne = row - 1;
                var colPlusOne = col + 1;
                var colMinusOne = col - 1;
                var countNeighbors = 0;

                if (board.GetLength(0) > rowPlusOne && board[rowPlusOne, col] == neighbor) countNeighbors++;
                if (rowMinusOne >= 0 && board[rowMinusOne, col] == neighbor) countNeighbors++;
                if (board.GetLength(1) > colPlusOne && board[row, colPlusOne] == neighbor) countNeighbors++;
                if (colMinusOne >= 0 && board[row, colMinusOne] == neighbor) countNeighbors++;
                if (colMinusOne >= 0 && rowMinusOne >= 0 && board[rowMinusOne, colMinusOne] == neighbor) countNeighbors++;
                if (board.GetLength(1) > colPlusOne && rowMinusOne >= 0 && board[rowMinusOne, colPlusOne] == neighbor) countNeighbors++;
                if (board.GetLength(0) > rowPlusOne && board.GetLength(1) > colPlusOne && board[rowPlusOne, colPlusOne] == neighbor) countNeighbors++;
                if (board.GetLength(0) > rowPlusOne && colMinusOne >= 0 && board[rowPlusOne, colMinusOne] == neighbor) countNeighbors++;

                return countNeighbors;
            }
        }

    }
}
