using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy3sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 11, 2, 5, 7, 3 };
            bool b = Has3Sum(l, 22);
        }

        public static bool Has3Sum(List<int> a, int t)
        {
            a.Sort();
            for (int i = 0; i < a.Count; ++i)
            {
                if (HasSum(a, i, t-a[i])) return true;
            }
            return false;
        }

        public static bool HasSum(List<int> a, int start, int t)
        {
            int left = start;
            int right = a.Count - 1;

            while (left < right)
            {
                if (a[left] + a[right] == t) return true;
                if (a[left] + a[right] < t)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return false;
        }
    }
}
