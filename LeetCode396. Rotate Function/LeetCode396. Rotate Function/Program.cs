using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode396.Rotate_Function
{
    class Program
    {
        //https://leetcode.com/problems/rotate-function/discuss/
        //non optimal
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MaxRotateFunction(new int[] { 4,3,2,6});
        }

        public class Solution
        {
            public int MaxRotateFunction(int[] A)
            {
                var resp = new List<List<int>>();
                GetRotations(new List<int>(A), resp, 0);
                var max = 0;
                foreach (var l in resp)
                {
                    var v = 0;
                    for (int i = 0; i < l.Count; ++i)
                    {
                        v += l[i] * i;
                    }
                    max = Math.Max(v, max);
                }
                return max;
            }

            private void GetRotations(List<int> A, List<List<int>> resp, int rot)
            {
                if (rot == A.Count) return;

                var start = rot > 0 ? A.GetRange(A.Count - rot, rot) : null;
                var end = A.GetRange(0, A.Count - rot);
                var rotArry = new List<int>();
                if (start != null) rotArry.AddRange(start);
                rotArry.AddRange(end);
                resp.Add(rotArry);
                GetRotations(A, resp, rot + 1);
            }
        }
    }
}
