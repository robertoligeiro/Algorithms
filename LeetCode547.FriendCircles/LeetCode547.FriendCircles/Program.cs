using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode547.FriendCircles
{
    https://leetcode.com/problems/friend-circles/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var m = new int[,] { { 1,0,0,1},
                                 { 0,1,1,0},
                                 { 0,1,1,1},
                                 { 1,0,1,1}
                                };

            var s = new Solution();
            var r = s.FindCircleNum(m);
        }

        public class Solution
        {
            public void dfs(int[,] M, int[] visited, int i)
            {
                for (int j = 0; j < M.GetLength(0); j++)
                {
                    if (M[i,j] == 1 && visited[j] == 0)
                    {
                        visited[j] = 1;
                        dfs(M, visited, j);
                    }
                }
            }
            public int FindCircleNum(int[,] M)
            {
                int[] visited = new int[M.GetLength(0)];
                int count = 0;
                for (int i = 0; i < M.GetLength(0); i++)
                {
                    if (visited[i] == 0)
                    {
                        dfs(M, visited, i);
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
