using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode384.ShuffleanArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution(new int[] { 1,2,3});
            var r = s.Shuffle();
        }

        public class Solution
        {
            private int[] array;
            private Random rand;
            public Solution(int[] nums)
            {
                array = nums;
                rand = new Random();
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                return array;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                var sarray = (int [])array.Clone();
                for (int i = 0; i < sarray.Length; ++i)
                {
                    var to = i+rand.Next(array.Length-i);
                    var t = sarray[to];
                    sarray[to] = sarray[i];
                    sarray[i] = t;
                }
                return sarray;
            }
        }
    }
}
