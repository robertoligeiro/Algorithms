using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode593.Valid_Square
{
    class Program
    {
        //https://leetcode.com/problems/valid-square/description/
        //solution based on #3https://leetcode.com/problems/valid-square/solution/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.ValidSquare(new int[] { 6987, -473 }, new int[] { 6985,-473}, new int[] { 6986,-472}, new int[] { 6986,-474} );
            //var r = s.ValidSquare(new int[] { 1,4}, new int[] { 1,6 }, new int[] { 4,1 }, new int[] { 6,3 });
        }

        public class Solution
        {
            public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
            {
                var l = new List<int[]>() {p1,p2,p3,p4};
                l.Sort(compare);
                return dist(l[0], l[1]) != 0 && dist(l[0], l[1]) == dist(l[1], l[3]) && dist(l[1], l[3]) == dist(l[3], l[2]) && dist(l[3], l[2]) == dist(l[2], l[0]) && dist(l[0], l[3]) == dist(l[1], l[2]);
            }

            private double dist(int[] p1, int[] p2)
            {
                return (p2[1] - p1[1]) * (p2[1] - p1[1]) + (p2[0] - p1[0]) * (p2[0] - p1[0]);
            }
            private int compare(int[] p1, int[] p2)
            {
                if (p1[0].CompareTo(p2[0]) == 0)
                {
                    return p1[1].CompareTo(p2[1]);
                }
                return p1[0].CompareTo(p2[0]);
            }
        }
    }
}
