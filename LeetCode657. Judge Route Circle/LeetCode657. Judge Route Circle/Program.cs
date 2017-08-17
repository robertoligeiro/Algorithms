using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode657.Judge_Route_Circle
{
    class Program
    {
        //https://leetcode.com/problems/judge-route-circle/description/
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public bool JudgeCircle(string moves)
            {
                var x = 0;
                var y = 0;
                foreach (var c in moves)
                {
                    switch(c)
                    {
                        case 'U':
                            y--;
                            break;
                        case 'D':
                            y++;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'R':
                            x++;
                            break;
                    }
                }
                return x == 0 && y == 0;
            }
        }
    }
}
