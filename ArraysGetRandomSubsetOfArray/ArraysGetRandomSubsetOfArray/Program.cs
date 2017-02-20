using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysGetRandomSubsetOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetSubset(10, 10);
        }

        public static List<int> GetSubset(int n, int k)
        {
            var dict = new Dictionary<int, int>();
            var rand = new Random();
            for (int i = 0; i < k; ++i)
            {
                int index = rand.Next(i, n - 1);
                int v;
                if (dict.TryGetValue(index, out v))
                {
                    dict[index] = i;
                    dict[i] = v;
                }else
                if (dict.TryGetValue(i, out v))
                {
                    dict[i] = index;
                    dict.Add(index, v);
                }
                else
                {
                    dict.Add(index, i);
                    if(index != i)
                        dict.Add(i, index);
                }
            }

            var r = new List<int>();
            for (int i = 0; i < k; ++i)
            {
                r.Add(dict[i]);
            }
            return r;
        }
    }
}
