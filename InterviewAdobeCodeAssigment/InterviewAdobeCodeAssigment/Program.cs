using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAdobeCodeAssigment
{
    class Program
    {
        static void Main(string[] args)
        {

            // map, 6 elements, all set to 100
            var rle = new rle_int_map(6, 100);

            // check all values == 100
            for (int i = 0; i < 6; ++i)
            {
                Debug.Assert(rle.Get(i) == 100);
            }

            //SET index 3 to 3.
            rle.Set(3, 3);
            //check previous values are still 100 but 3.
            Debug.Assert(rle.Get(0) == 100);
            Debug.Assert(rle.Get(1) == 100);
            Debug.Assert(rle.Get(2) == 100);
            Debug.Assert(rle.Get(3) == 3);
            Debug.Assert(rle.Get(4) == 100);
            Debug.Assert(rle.Get(5) == 100);


            //SET index 0 to 0
            rle.Set(0, 0);
            Debug.Assert(rle.Get(0) == 0);
            Debug.Assert(rle.Get(1) == 100);
            Debug.Assert(rle.Get(2) == 100);
            Debug.Assert(rle.Get(3) == 3);
            Debug.Assert(rle.Get(4) == 100);
            Debug.Assert(rle.Get(5) == 100);

            //SET index 1 to 1
            rle.Set(1, 1);
            Debug.Assert(rle.Get(0) == 0);
            Debug.Assert(rle.Get(1) == 1);
            Debug.Assert(rle.Get(2) == 100);
            Debug.Assert(rle.Get(3) == 3);
            Debug.Assert(rle.Get(4) == 100);
            Debug.Assert(rle.Get(5) == 100);

            rle.Set(2, 2);
            Debug.Assert(rle.Get(0) == 0);
            Debug.Assert(rle.Get(1) == 1);
            Debug.Assert(rle.Get(2) == 2);
            Debug.Assert(rle.Get(3) == 3);
            Debug.Assert(rle.Get(4) == 100);
            Debug.Assert(rle.Get(5) == 100);

            rle.Set(4, 4);
            Debug.Assert(rle.Get(0) == 0);
            Debug.Assert(rle.Get(1) == 1);
            Debug.Assert(rle.Get(2) == 2);
            Debug.Assert(rle.Get(3) == 3);
            Debug.Assert(rle.Get(4) == 4);
            Debug.Assert(rle.Get(5) == 100);

            rle.Set(5, 5);
            Debug.Assert(rle.Get(0) == 0);
            Debug.Assert(rle.Get(1) == 1);
            Debug.Assert(rle.Get(2) == 2);
            Debug.Assert(rle.Get(3) == 3);
            Debug.Assert(rle.Get(4) == 4);
            Debug.Assert(rle.Get(5) == 5);
        }

        public class Run
        {
            public int m_stop { get; set; }
            public int m_value { get; set; }
        }
        public class rle_int_map
        {
            private List<Run> mRuns;

            public rle_int_map(int num_values, int initial_val)
            {
                mRuns = new List<Run>() { new Run() { m_stop = num_values, m_value = initial_val, } };
            }

            public int Get(int index)
            {
                this.ValidateIndex(index);
                return this.mRuns[this.FindRunIndexBinSearch(index)].m_value;
            }

            public void Set(int index, int value)
            {
                this.ValidateIndex(index);
                var runIndex = this.FindRunIndexBinSearch(index);

                if (runIndex > 0)
                {
                    if (this.mRuns[runIndex].m_stop - 1 == this.mRuns[runIndex - 1].m_stop)
                    {
                        this.mRuns[runIndex].m_value = value;
                        return;
                    }
                }

                var ToAdd = new List<Run>();
                if (index > 0)
                {
                    if (runIndex == 0 ||
                    this.mRuns[runIndex - 1].m_stop != index)
                    {
                        ToAdd.Add(new Run() { m_stop = index, m_value = this.mRuns[runIndex].m_value });
                    }
                }
                ToAdd.Add(new Run() { m_stop = index + 1, m_value = value });
                this.mRuns.AddRange(ToAdd);
                this.mRuns.Sort(SortRun);
            }

            private int SortRun(Run a, Run b)
            {
                return a.m_stop.CompareTo(b.m_stop);
            }

            private int FindRunIndexBinSearch(int index)
            {
                var left = 0;
                var right = this.mRuns.Count - 1;
                var resp = 0;
                while (left <= right)
                {
                    var mid = left + (right - left) / 2;
                    if (mRuns[mid].m_stop > index)
                    {
                        resp = mid;
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return resp;
            }

            private void ValidateIndex(int index)
            {
                if (index < 0 || index > mRuns.Last().m_stop - 1)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public class IntMap
        {
            private int[] map;

            private void ValidateIndex(int index)
            {
                if (index < 0 || index > map.Length - 1)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            public IntMap(int num_values, int initial_val)
            {
                map = Enumerable.Repeat(initial_val, num_values).ToArray();
            }

            public int Get(int index)
            {
                ValidateIndex(index);
                return this.map[index];
            }

            public void Set(int index, int value)
            {
                ValidateIndex(index);
                this.map[index] = value;
            }
        }
    }
}
