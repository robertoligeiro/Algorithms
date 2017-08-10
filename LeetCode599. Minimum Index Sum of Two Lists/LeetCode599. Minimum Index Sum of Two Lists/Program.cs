using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode599.Minimum_Index_Sum_of_Two_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public string[] FindRestaurant(string[] list1, string[] list2)
            {
                var m = new Dictionary<string, int>();
                for(var i = 0; i < list1.Length; ++i)
                {
                    m.Add(list1[i], i);
                }

                var resp = new List<string>();
                var minDist = int.MaxValue;
                for (int i = 0; i < list2.Length; ++i)
                {
                    var index = 0;
                    if (m.TryGetValue(list2[i], out index))
                    {
                        var localDist = index + i;
                        if (localDist == minDist) resp.Add(list2[i]);
                        else if (localDist < minDist)
                        {
                            resp.Clear();
                            resp.Add(list2[i]);
                            minDist = localDist;
                        }
                    }
                }
                return resp.ToArray();
            }
        }
    }
}
