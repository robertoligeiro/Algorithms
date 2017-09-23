using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBloombergScreen
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = 0;
            r = FindNonRepeated(new List<int>() { 1 }); //1
            r = FindNonRepeated(new List<int>() { 1, 1, 2 }); //2
            r = FindNonRepeated(new List<int>() { 1, 2, 2 }); // 1
            r = FindNonRepeated(new List<int>() { 1, 1, 2, 2, 3 }); //3
            r = FindNonRepeated(new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5, 5 }); //4
            r = FindNonRepeated(new List<int>() { 1, 1, 2, 3, 3, 4, 4, 5, 5 }); //2
            r = FindNonRepeated(new List<int>() { 1, 2, 2, 3, 3, 4, 4, 5, 5 }); // 1
            r = FindNonRepeated(new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 5 }); //5
            r = FindNonRepeated(new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6 }); //6
            r = FindNonRepeated(new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 5, 6, 6 }); //5
        }

        public static int FindNonRepeated(List<int> nums)
        {
            var l = 0;
            var r = nums.Count;
            while (l < r)
            {
                var mid = l + (r - l) / 2;
                if (mid % 2 == 0)
                {
                    if (mid + 1 < nums.Count && nums[mid] == nums[mid + 1]) l = mid + 2;
                    else r = mid - 1;
                }
                else
                {
                    if (mid + 1 < nums.Count && nums[mid] == nums[mid + 1]) r = mid - 1;
                    else l = mid + 1;
                }
            }
            return nums[l];
        }

        public static int FindNonRepeated2(List<int> nums)
        {
            return FindNonRepeated2(nums, 0, nums.Count - 1);
        }
        public static int FindNonRepeated2(List<int> nums, int l, int r)
        {
            if (l > r) throw new ArgumentException("non repeated doesn't exist");
            if (l == r) return nums[l];
            var mid = l + (r - l) / 2;
            if (mid % 2 == 0)
            {
                if (nums[mid] == nums[mid + 1])
                {
                    return FindNonRepeated(nums, mid + 2, r);
                }
                return FindNonRepeated(nums, l, mid);
            }

            if (nums[mid] == nums[mid - 1])
            {
                return FindNonRepeated(nums, mid + 1, r);
            }
            else
            {
                return FindNonRepeated(nums, l, mid - 1);
            }
        }
    }
}
