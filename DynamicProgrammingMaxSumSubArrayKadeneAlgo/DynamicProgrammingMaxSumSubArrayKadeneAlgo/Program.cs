using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingMaxSumSubArrayKadeneAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindMaxSubArray(new List<int>() { -9, 2, 4, -5, 6 });
        }

        class MaxSub
        {
            public int i { set; get; }
            public int j { set; get; }
            public int sum{set;get;}
        }

        static MaxSub FindMaxSubArray(List<int> a)
        {
            var resp = new MaxSub();
            var curr = new MaxSub() { i = -1};
            for (int i = 0; i < a.Count; ++i)
            {
                if (curr.sum + a[i] > 0)
                {
                    curr.i = curr.i == -1 ? i : curr.i;
                    curr.j = i;
                    curr.sum += a[i];
                    if (curr.sum > resp.sum)
                    {
                        resp = curr;
                    }
                }
                else
                {
                    curr.sum = 0;
                    curr.i = -1;
                }
            }

            return resp;
        }
    }
}
