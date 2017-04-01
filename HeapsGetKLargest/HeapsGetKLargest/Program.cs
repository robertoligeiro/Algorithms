using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsGetKLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 561, 314, 401, 28, 156, 359, 271, 11, 3 };
            var r = GetKLargest(l, 4);
        }

        public static List<int> GetKLargest(List<int> heap, int k)
        {
            var sDict = new SortedDictionary<int, int>();
            var resp = new List<int>();
            sDict.Add(heap[0], 0);
            while (resp.Count < k)
            {
                var t = sDict.LastOrDefault();
                sDict.Remove(t.Key);
                resp.Add(t.Key);
                var leftChild = t.Value * 2 + 1;
                var rightChild = t.Value * 2 + 2;
                if(leftChild < heap.Count)
                    sDict.Add(heap[leftChild], leftChild);
                if (rightChild < heap.Count)
                    sDict.Add(heap[rightChild], rightChild);
            }
            return resp;
        }
    }
}
