using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode476.Number_Complement
{
    class Program
    {
        //https://leetcode.com/problems/number-complement/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindComplement(5);
        }
        public class Solution
        {
            public int FindComplement(int num)
            {
                var mult = 1;
                var comp = 0;
                while (num > 0)
                {
                    if ((num & 1) == 0)
                    {
                        comp += mult;
                    }
                    num >>= 1;
                    mult *= 2;
                }
                return comp;
            }
        }
    }
}
