using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode455.AssignCookies
{
    class Program
    {
        //https://leetcode.com/problems/assign-cookies/description/

        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public int FindContentChildren(int[] g, int[] s)
            {
                if (g == null || s == null || g.Length == 0 || s.Length == 0) return 0;
                var lG = new List<int>(g);
                var lS = new List<int>(s);
                lG.Sort();
                lS.Sort();
                var indexG = 0;
                var indexS = 0;
                var resp = 0;
                while (indexG < lG.Count && indexS < lS.Count)
                {
                    if (lS[indexS] >= lG[indexG])
                    {
                        resp++;
                        indexG++;
                        indexS++;
                    }
                    else if(lS[indexS] < lG[indexG]) indexS++;
                }
                return resp;
            }
        }
    }
}
