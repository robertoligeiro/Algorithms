using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewOraclePhone
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BiggestProduct(new List<int>() { 4,5 }); // 20
            r = BiggestProduct(new List<int>() { 1, 2, 4, 5 }); // 20
            r = BiggestProduct(new List<int>() { -6, -5, 3, 4, 5 }); // 30
            r = BiggestProduct(new List<int>() { 4, 5, 5, 1, -1 }); // 25
            r = BiggestProduct(new List<int>() { -7, 5, 5, 1, -1, -7 }); // 49
            r = BiggestProduct(new List<int>() { 2,2,2,2,2 }); // 4
        }

        public static long BiggestProduct(List<int> nums)
        {
            if (nums == null || nums.Count == 0 || nums.Count == 1)
            {
                throw new ArgumentException("wrong list size or null list.");
            }

            var max = new List<int>();
            var min = new List<int>();
            foreach (var i in nums)
            {
                if (max.Count < 2)
                {
                    max.Add(i);
                }
                else
                {
                    max.Sort();
                    if (max[0] < i) max[0] = i;
                }
                if (min.Count < 2)
                {
                    min.Add(i);
                }
                else
                {
                    min.Sort();
                    if (min[1] > i) min[1] = i;
                }
            }

            return Math.Max((long)max[0] * max[1], (long)min[0] * min[1]);
        }
    }
}
