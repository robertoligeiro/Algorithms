using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode600.NonnegativeIntswithoutConsecOnes
{
    //https://leetcode.com/problems/non-negative-integers-without-consecutive-ones/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindIntegers(10);
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
        }
        public class Solution
        {
            public int FindIntegers(int num)
            {
                var root = new Node() { val = 0, left = new Node() { val = 0}, right = new Node() { val = 1} };
                var count = 2;
                CreateTree(root.left, num, true, 0, 2, ref count, 1);
                CreateTree(root.right, num, false, 0, 2, ref count, 1);
                return count;
            }

            public void CreateTree(Node n, int num, bool countOne, int currValue, int mult, ref int count, int h)
            {
                var acc = n.val * mult + currValue;
                mult *= 2;
                if (acc > num || Math.Pow(2, h) > num) return;
                n.left = new Node() { val = 0 };
                if (n.val == 0)
                {
                    n.right = new Node() { val = 1 };
                }
                else
                {
                    count++;
                    if (countOne && acc < num) count++;
                }
                CreateTree(n.left, num, countOne, acc, mult, ref count, h+1);
                if (n.right != null)
                    CreateTree(n.right, num, countOne, acc, mult, ref count, h+1);

            }
        }
    }
}
