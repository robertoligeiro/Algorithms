using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode295.FindMedianfromDataStream
{
    class Program
    {
        //https://leetcode.com/problems/find-median-from-data-stream/#/description
        static void Main(string[] args)
        {
            var median = 0.0;
            var m = new MedianFinder();
            m.AddNum(6);
            m.AddNum(2);
            median = m.FindMedian();
            m.AddNum(4);
            median = m.FindMedian();
            m.AddNum(3);
            median = m.FindMedian();
            m.AddNum(1);
            median = m.FindMedian();
            m.AddNum(5);
            median = m.FindMedian();
        }
        public class MedianFinder
        {
            private SortedList<int, int> min;
            private SortedList<int, int> max;
            private int countMin = 0;
            private int countMax = 0;

            private void AddToList(SortedList<int, int> list, int num)
            {
                var count = 0;
                if (list.TryGetValue(num, out count))
                {
                    list[num] = ++count;
                }
                else list.Add(num, 1);
            }
            /** initialize your data structure here. */
            public MedianFinder()
            {
                min = new SortedList<int, int>();
                max = new SortedList<int, int>();
            }

            public void AddNum(int num)
            {
                if (countMin == 0 || num >= min.FirstOrDefault().Key)
                {
                    countMin++;
                    this.AddToList(this.min, num);
                }
                else
                {
                    countMax++;
                    this.AddToList(this.max, num);
                }

                if (countMin > countMax + 1)
                {
                    countMin--;
                    var value = min.FirstOrDefault().Key;
                    if (--min[min.FirstOrDefault().Key] == 0)
                    {
                        min.Remove(min.FirstOrDefault().Key);
                    }
                    countMax++;
                    this.AddToList(this.max, value);
                }
                else if(countMax > countMin)
                {
                    countMax--;
                    var value = max.LastOrDefault().Key;
                    if (--max[max.LastOrDefault().Key] == 0)
                    {
                        max.Remove(max.LastOrDefault().Key);
                    }
                    countMin++;
                    this.AddToList(this.min, value);
                }
            }

            public double FindMedian()
            {
                if (countMin > countMax)
                {
                    return min.FirstOrDefault().Key;
                }
                return (double)(min.FirstOrDefault().Key + max.LastOrDefault().Key)/2;
            }
        }
    }
}
