using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsComputeMedianOfOnlineData
{
    class Program
    {
        static void Main(string[] args)
        {
            var Median = new Median();
            double m;
            m = Median.GetMedian(1);
            m = Median.GetMedian(0);
            m = Median.GetMedian(3);
            m = Median.GetMedian(5);
            m = Median.GetMedian(2);
            m = Median.GetMedian(0);
            m = Median.GetMedian(1);
        }

        public class Median
        {
            private SortedList<int,int> minH = new SortedList<int,int>();
            private SortedList<int,int> maxH = new SortedList<int,int>();
            private int minCount = 0;
            private int maxCount = 0;

            public double GetMedian(int i)
            {
                if (minCount == 0)
                {
                    minCount++;
                    minH.Add(i,1);
                }
                else
                {
                    if (i >= minH.FirstOrDefault().Key)
                    {
                        minCount++;
                        AddToList(minH, i);
                    }
                    else
                    {
                        maxCount++;
                        AddToList(maxH, i);
                    }
                }

                if (minCount > maxCount + 1)
                {
                    maxCount++;
                    AddToList(maxH, minH.FirstOrDefault().Key);
                    int v;
                    minCount--;
                    if (minH.TryGetValue(minH.FirstOrDefault().Key, out v))
                    {
                        if (v == 1)
                            minH.Remove(minH.FirstOrDefault().Key);
                        else
                            minH[minH.FirstOrDefault().Key] = --v;
                    }
                }
                else
                {
                    if (maxCount > minCount)
                    {
                        minCount++;
                        AddToList(minH, maxH.LastOrDefault().Key);
                        maxH.Remove(maxH.LastOrDefault().Key);
                        int v;
                        maxCount--;
                        if (maxH.TryGetValue(maxH.LastOrDefault().Key, out v))
                        {
                            if (v == 0)
                                maxH.Remove(maxH.LastOrDefault().Key);
                            else
                                maxH[maxH.LastOrDefault().Key] = --v;
                        }
                    }
                }

                if (minCount == maxCount) return (double)(minH.FirstOrDefault().Key + maxH.LastOrDefault().Key) / 2;
                return minH.FirstOrDefault().Key;
            }

            private void AddToList(SortedList<int, int> l, int i)
            {
                int v;
                if (l.TryGetValue(i, out v))
                {
                    l[i] = ++v;
                }
                else
                    l.Add(i, 1);
            }
        }
    }
}
