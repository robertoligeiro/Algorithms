using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode274.H_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.HIndex(new int[] { 3,0,6,1,5});
            //var r = s.HIndex(new int[] { 2,1 });
            var r = s.HIndex(new int[] { 3,3,3,0,1,5 });
        }

        public class Solution
        {
            public int HIndex(int[] citations)
            {
                var cit = new List<int>(citations);
                cit.Sort();
                //cit.Reverse();
                int result = 0;
                for (int i = 0; i < cit.Count; i++)
                {
                    int smaller = Math.Min(cit[i], cit.Count - i);
                    result = Math.Max(result, smaller);
                }

                return result;
            }
        }
    }
}
