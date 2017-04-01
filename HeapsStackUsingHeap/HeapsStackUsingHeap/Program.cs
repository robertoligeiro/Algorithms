using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsStackUsingHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new StackUsingHeap();
            s.Push(0);
            s.Push(1);
            s.Push(2);
            s.Push(-1);
            s.Push(3);
            var r = s.Pop(); // 3
            s.Push(5);
            s.Push(-4);
            r = s.Pop(); // -4
            r = s.Pop(); //5
            r = s.Pop(); //-1
            r = s.Pop(); //2
            r = s.Pop(); //1
            r = s.Pop(); //0
            r = s.Pop(); // exception underflow
        }

        public class StackUsingHeap
        {
            private SortedDictionary<int, int> heap = new SortedDictionary<int, int>();
            private int heapIndex = 0;

            public void Push(int i)
            {
                heap.Add(this.heapIndex--, i);
            }

            public int Pop()
            {
                if (heap.Count == 0) throw new Exception("Underflow");
                var r = heap.FirstOrDefault();
                heap.Remove(r.Key);
                return r.Value;
            }
        }
    }
}
