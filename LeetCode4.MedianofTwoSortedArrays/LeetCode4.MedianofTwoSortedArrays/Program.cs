using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode4.MedianofTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.FindMedianSortedArrays(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7, 8 });
            //var r = s.FindMedianSortedArrays(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7, 8 });
            var r = s.FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 });
        }
        public class Solution
        {
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {
                int m = 0;
                if ((nums1 == null || nums1.Length == 0) && (nums2 == null || nums2.Length == 0)) return 0;
                if (nums1 == null || nums1.Length == 0) return CalcMedianOfArray(nums2, 0, nums2.Length - 1, ref m);
                if (nums2 == null || nums2.Length == 0) return CalcMedianOfArray(nums1, 0, nums1.Length - 1, ref m);
                return FindMedianSortedArrays(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1);
            }

            public double FindMedianSortedArrays(int[] n1, int l1, int r1, int[] n2, int l2, int r2)
            {
                var s1 = r1 - l1 + 1;
                var s2 = r2 - l2 + 1;
                if (s1 == 2 && s2 == 2)
                {
                    return (double)(Math.Max(n1[l1], n2[l2]) + Math.Min(n1[r1], n2[r2])) / 2; 
                }
                var mid1 = 0;
                var med1 = CalcMedianOfArray(n1, l1, r1, ref mid1);
                var mid2 = 0;
                var med2 = CalcMedianOfArray(n2, l2, r2, ref mid2);
                if (med1 == med2) return med1;
                if (med1 < med2)
                {
                    return FindMedianSortedArrays(n1, mid1, r1, n2, l2, mid2);
                }
                return FindMedianSortedArrays(n1, l1, mid1, n2, mid2, r2);
            }
            public double CalcMedianOfArray(int[] a, int l, int r, ref int m)
            {
                if (l >= r) return a[l];

                var s = r - l + 1;
                m = l + (r - l)/2;
                if (s % 2 == 0)
                {
                    return (double)(a[m] + a[m + 1]) / 2;
                }

                return a[m];
            }
        }
    }
}
