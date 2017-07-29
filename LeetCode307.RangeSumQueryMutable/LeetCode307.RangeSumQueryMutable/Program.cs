using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode307.RangeSumQueryMutable
{
    //https://leetcode.com/problems/range-sum-query-mutable/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new NumArray(new int[] { 2, 4, 8, 1, 3 });
            var r = s.SumRange(0,4);
            r = s.SumRange(1,4);

            s.Update(3, 4);
            r = s.SumRange(0, 4);
            r = s.SumRange(1, 4);

            s = new NumArray(new int[] { 1,3,5 });
            r = s.SumRange(0, 2);
            s.Update(1, 2);
        }
        public class Tree
        {
            public Tree left { get; set; }
            public Tree right { get; set; }
            public Tuple<int, int> range { get; set; }
            public int sum { get; set; }
        }
        public class NumArray
        {
            private Tree rangeTree;
            public NumArray(int[] nums)
            {
                this.rangeTree = BuildRangeTree(nums);
            }

            public void Update(int i, int val)
            {
                UpdateTree(this.rangeTree, i, val);
            }

            public int SumRange(int i, int j)
            {
                return GetSumRange(this.rangeTree, i, j);
            }

            private int UpdateTree(Tree n, int index, int val)
            {
                var diff = 0;
                if (n.range.Item1 == n.range.Item2)
                {
                    diff = val - n.sum;
                    n.sum = val;
                    return diff;
                }
                var mid = n.range.Item1 + (n.range.Item2 - n.range.Item1) / 2;
                if (index <= mid)
                {
                    diff = UpdateTree(n.left, index, val);
                }
                else
                {
                    diff = UpdateTree(n.right, index, val);
                }

                n.sum += diff;
                return diff;
            }

            private int GetSumRange(Tree n, int start, int end)
            {
                if (n == null) return -1;
                if (n.range.Item1 == start && n.range.Item2 == end) return n.sum;
                else
                {
                    var mid = n.range.Item1 + (n.range.Item2 - n.range.Item1) / 2;
                    if (end <= mid)
                    {
                        return GetSumRange(n.left, start, end);
                    }
                    else if (start >= mid + 1)
                    {
                        return GetSumRange(n.right, start, end);
                    }
                    else
                    {
                        return GetSumRange(n.left, start, mid ) + GetSumRange(n.right, mid + 1, end);
                    }
                }
            }
            private Tree BuildRangeTree(int[] nums)
            {
                return BuildRangeTree(nums, 0, nums.Length - 1);
            }

            private Tree BuildRangeTree(int[]nums, int start, int end)
            {
                if (start > end) return null;
                if (start == end)
                {
                    return new Tree() { sum = nums[start], range = new Tuple<int, int>(start, end) };
                }
                var node = new Tree() { range = new Tuple<int, int>(start, end) };
                var mid = start + (end - start) / 2;
                node.left = BuildRangeTree(nums, start, mid);
                node.right = BuildRangeTree(nums, mid + 1, end);
                node.sum = node.left.sum + node.right.sum;
                return node;
            }
        }
    }
}
