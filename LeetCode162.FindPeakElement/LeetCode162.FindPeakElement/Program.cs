using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode162.FindPeakElement
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public int FindPeakElement(int[] nums)
            {
                int low = 0;
                int high = nums.Length - 1;

                while (low < high)
                {
                    int mid1 = (low + high) / 2;
                    int mid2 = mid1 + 1;
                    if (nums[mid1] < nums[mid2])
                        low = mid2;
                    else
                        high = mid1;
                }
                return low;
            }
        }
    }
}
