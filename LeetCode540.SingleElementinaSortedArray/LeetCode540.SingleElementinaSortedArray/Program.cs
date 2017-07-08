using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode540.SingleElementinaSortedArray
{
    class Program
    {
        //https://leetcode.com/problems/single-element-in-a-sorted-array/#/description
        // solution: https://leetcode.com/problems/single-element-in-a-sorted-array/#/solutions
        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public int SingleNonDuplicate(int[] nums)
            {
                var l = 0;
                var r = nums.Length - 1;
                while (l < r)
                {
                    var mid = l + (r - l) / 2;
                    if (nums[mid] != nums[mid + 1] && nums[mid] != nums[mid - 1])
                    {
                        return nums[mid];
                    }
                    if (nums[mid] == nums[mid + 1] && mid % 2 == 0)
                    {
                        l = mid + 1;
                    }
                    else if (nums[mid] == nums[mid - 1] && mid % 2 == 1)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return nums[l];
            }
        }
    }
}
