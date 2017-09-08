using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode419.Battleships_in_a_Board
{
    class Program
    {
        //https://leetcode.com/problems/battleships-in-a-board/description/
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public int CountBattleships(char[,] board)
            {
                var resp = 0;
                for (int row = 0; row < board.GetLength(0); ++row)
                {
                    for (int col = 0; col < board.GetLength(1); ++col)
                    {
                        if (board[row, col] == 'X')
                        {
                            RemoveShip(row,col, board);
                            resp++;
                        }
                    }
                }
                return resp;
            }

            public void RemoveShip(int row, int col, char[,] board)
            {
                if (col + 1 < board.GetLength(1) && board[row, col + 1] == 'X')
                {
                    while (col < board.GetLength(1) && board[row, col] == 'X') board[row, col++] = '*';
                    return;
                }
                if (row + 1 < board.GetLength(0) && board[row + 1, col] == 'X')
                {
                    while (row < board.GetLength(0) && board[row, col] == 'X') board[row++, col] = '*';
                }
            }
        }
    }
}
