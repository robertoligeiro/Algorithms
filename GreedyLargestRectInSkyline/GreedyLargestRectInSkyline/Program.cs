using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyLargestRectInSkyline
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 2, 1, 2, 3, 1 };
            var r = GetMaxArea(l);
        }

        public static int GetMaxArea(List<int> a)
        {
            var sValues = new Stack<int>();
            int i = 0;
            int top = 0;
            int maxArea = 0;
            for (; i < a.Count;)
            {
                if (sValues.Count == 0 || sValues.Peek() <= a[i])
                {
                    sValues.Push(a[i++]);
                }
                else
                {
                    while (sValues.Count > 0 && sValues.Peek() >= a[i])
                    {
                        top = sValues.Pop();
                        int area;
                        if (sValues.Count == 0)
                        {
                            area = a[top] * i;
                            maxArea = maxArea > area ? maxArea : area;
                        }
                        else
                        {
                            area = a[top] * (i - sValues.Peek() - 1);
                            maxArea = maxArea > area ? maxArea : area;
                        }
                    }
                }
            }

            while (sValues.Count > 0)
            {
                top = sValues.Pop();
                int area;
                if (sValues.Count == 0)
                {
                    area = a[top] * i;
                    maxArea = maxArea > area ? maxArea : area;
                }
                else
                {
                    area = a[top] * (i - sValues.Peek() - 1);
                    maxArea = maxArea > area ? maxArea : area;
                }
            }

            return maxArea;
        }
    }
}
