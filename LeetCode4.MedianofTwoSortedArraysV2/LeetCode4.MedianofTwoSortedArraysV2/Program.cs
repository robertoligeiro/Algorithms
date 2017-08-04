using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode4.MedianofTwoSortedArraysV2
{
    class Program
    {
        //https://leetcode.com/problems/median-of-two-sorted-arrays/description/
        static void Main(string[] args)
        {
            var median = FindMedianSortedArrays(new int[] { 1,2,6 }, new int[] {3,4,5 });
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            return FindMedianSortedArrays(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1);
        }
        public static double FindMedianSortedArrays(int[] n1, int l1, int r1, int[] n2, int l2, int r2)
        {
            var size1 = r1 - l1 + 1;
            var size2 = r2 - l2 + 1;
            if (size1 == 2 && size2 == 2)
            {
                return (double)(Math.Max(n1[l1], n2[l2]) + Math.Min(n1[r1], n2[r2])) / 2; 
            }
            var mid1 = 0;
            var mid2 = 0;
            var m1 = GetMedian(n1, l1, r1, ref mid1);
            var m2 = GetMedian(n2, l2, r2, ref mid2);
            if (m1 == m2) return m1;
            if (m1 < m2) //n1 go right, n2 go left
            {
                return FindMedianSortedArrays(n1, mid1, r1, n2, l2, mid2);
            }
            return FindMedianSortedArrays(n1, l1, mid1, n2, mid2, r2);
        }

        public static double GetMedian(int[]n, int l, int r, ref int mid)
        {
            if (l >= r) return n[l];
            var size = r - l + 1;
            mid = l + (r - l) / 2;
            if (size % 2 == 0)
            {
                return (double)(n[mid] + n[mid + 1]) / 2;
            }
            return n[mid];
        }
    }
}
