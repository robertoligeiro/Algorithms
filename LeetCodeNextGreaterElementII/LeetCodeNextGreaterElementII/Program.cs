using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNextGreaterElementII
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.NextGreaterElements(new int[] { 1, 2, 1 });
            //var r = s.NextGreaterElements(new int[] { 1, 2, 3, 4, 3 });
            //var r = s.NextGreaterElements(new int[] { 5, 4, 3, 2, 1 });
            //var r = s.NextGreaterElements(new int[] { 1, 1, 1, 1, 1 });
            var r = s.NextGreaterElements(new int[] { 1, 2, 3, 4, 5, 6, 5, 4, 5, 1, 2, 3 });
            //var r = s.NextGreaterElements(new int[] { 1, -2, -2, -1 });
            //var r = s.NextGreaterElements(new int[] { 7, -2, 6, 2, 4, -5, -9, -8, -4, -3 }); 
        }

        public class Solution
        {
            public int[] NextGreaterElements(int[] nums)
            {
                var l = new List<Tuple<int, int>>();
                var m = new Dictionary<Tuple<int, int>, int>();
                for (int i = 0; i < nums.Length; ++i)
                {
                    var t = new Tuple<int, int>(nums[i], i);
                    l.Add(t);
                }
                l.Sort();
                //for (int i = 0; i < nums.Length; ++i)
                //{
                //    m.Add(l[i], i);
                //}
                var countRemove = 0;
                var resp = new int[nums.Length];
                for (int i = 0; i < nums.Length; ++i)
                {
                    bool remove = false;
                    if (i > 0 && nums[i] < nums[i - 1]) remove = true;
                    var currT = new Tuple<int, int>(nums[i], i);
                    var t = GetIndex(currT, l);
                    //var t = l.IndexOf(currT);
                    //var t = m[currT];

                    if (t == l.Count - 1 || nums[i] == l[l.Count -1].Item1) resp[i] = -1;
                    else
                    {
                        int minSoFar = int.MaxValue;
                        int val = -1; 
                        for (int j = l.Count - 1; j >= t + 1; --j)
                        {
                            if (l[j].Item1 > nums[i])
                            {
                                var pos = 0;
                                if (l[j].Item2 > i)
                                {
                                    pos = (l[j].Item2 % nums.Length) - i;
                                }
                                else
                                {
                                    pos = nums.Length - i + l[j].Item2;
                                }
                                if (pos < minSoFar)
                                {
                                    minSoFar = pos;
                                    val = l[j].Item1;
                                    if (pos == 0) break;
                                }
                            }
                        }
                        resp[i] = val;
                        if (remove)
                        {
                            l.RemoveAt(t);
                            countRemove++;
                        } 
                    }
                }

                return resp;
            }

            public int GetIndex(Tuple<int, int> t, List<Tuple<int, int>> a)
            {
                int l = 0;
                int r = a.Count - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (t.Item1 == a[mid].Item1)
                    {
                        int i = mid;
                        while (i < a.Count && a[i].Item1 == t.Item1)
                        {
                            if (t.Item2 == a[i].Item2) return i;
                            ++i;
                        }
                        i = mid - 1;
                        while (i >= 0 && a[i].Item1 == t.Item1)
                        {
                            if (t.Item2 == a[i].Item2) return i;
                            --i;
                        }
                        return mid;
                    }
                    if (t.Item1 < a[mid].Item1)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                return -1;
            }
        }
    }
}
