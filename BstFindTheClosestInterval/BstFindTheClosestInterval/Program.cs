using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstFindTheClosestInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindClosestInterval(new List<List<int>>()
            {
                new List<int>(){ 5,10,15 },
                new List<int>(){ 3,6,9,12,15 },
                new List<int>(){ 8,16,24},
            });
        }

        public static List<int> FindClosestInterval(List<List<int>> a)
        {
            var q0 = new Queue<int>(a[0]);
            var q1 = new Queue<int>(a[1]);
            var q2 = new Queue<int>(a[2]);

            var resp = new List<int>();
            var minDiffSoFar = int.MaxValue;
            var diffList = new List<Tuple<int, int>>();
            diffList.Add(new Tuple<int, int>(q0.Dequeue(), 0));
            diffList.Add(new Tuple<int, int>(q1.Dequeue(), 1));
            diffList.Add(new Tuple<int, int>(q2.Dequeue(), 2));
            while (q0.Count >= 0 && q1.Count >= 0 && q2.Count >= 0)
            {
                diffList.Sort();
                if (diffList.Count != 3) break;
                var localDiff = (diffList[2].Item1 - diffList[1].Item1) + (diffList[1].Item1 - diffList[0].Item1);
                if (localDiff < minDiffSoFar)
                {
                    minDiffSoFar = localDiff;
                    resp = diffList.Select(x => x.Item1).ToList();
                }
                var t = diffList[0];
                diffList.RemoveAt(0);
                if (t.Item2 == 0 && q0.Count > 0) diffList.Add(new Tuple<int, int>(q0.Dequeue(), 0));
                if (t.Item2 == 1 && q1.Count > 0) diffList.Add(new Tuple<int, int>(q1.Dequeue(), 1));
                if (t.Item2 == 2 && q2.Count > 0) diffList.Add(new Tuple<int, int>(q2.Dequeue(), 2));
            }
            return resp;
        }
    }
}
