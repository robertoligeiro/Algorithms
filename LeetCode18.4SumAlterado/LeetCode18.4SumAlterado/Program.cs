using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode18._4SumAlterado
{
    class Program
    {
        //https://leetcode.com/problems/4sum/#/solutions - alter version, problem uses 2d, I simplified it to 1d array
        static void Main(string[] args)
        {
            var r = FourSum(new List<int> { 1, 2, -1, 4, 3 }, 5); //-1,1,2,3
            r = FourSum(new List<int> { 1, 2, -1, 4, 3 }, 6); //-1,1,2,4
            r = FourSum(new List<int> { 1, 2, -1, 4, 3 }, 8); //null
        }

        public static List<int> FourSum(List<int> a, int tgt)
        {
            a.Sort();
            for (int i = 0; i < a.Count; ++i)
            {
                var sum = tgt - a[i]; 
                for (int j = i + 1; j < a.Count; ++j)
                {
                    sum -= a[j];
                    var l = j + 1;
                    var r = a.Count - 1;
                    while (l < r)
                    {
                        var sumTwo = a[l] + a[r];
                        if (sumTwo == sum)
                        {
                            return new List<int>() { a[i], a[j], a[l], a[r] };
                        }
                        if (sumTwo > sum) r--;
                        else l++;
                    }
                }
            }
            return null;
        }
    }
}
