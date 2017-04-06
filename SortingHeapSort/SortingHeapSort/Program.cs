using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var minHeap = new MinHeap();
            minHeap.Add(5);
            minHeap.Add(4);
            minHeap.Add(3);
            minHeap.Add(6);
            minHeap.Add(0);
            minHeap.Add(1);
            minHeap.Add(7);

            var r = new List<int>();
            for (int i = 0; i < 7; ++i)
            {
                r.Add(minHeap.GetMin());
            }
        }

        public class MinHeap
        {
            private int[] heap = new int[10];
            private int size = 0;
            private Tuple<int, int> GetChildren(int n)
            {
                return new Tuple<int, int>(n * 2 + 1, n * 2 + 2);
            }

            private int GetParent(int n)
            {
                if (n % 2 == 0) return n / 2 - 1;
                return n / 2;
            }
            private void Swap(int a, int b)
            {
                var t = heap[a];
                heap[a] = heap[b];
                heap[b] = t;
            }
            private void MoveUp(int p)
            {
                int parent = GetParent(p);
                if (p < 0 || parent < 0) return;
                if (heap[parent] > heap[p])
                {
                    Swap(parent, p);
                    MoveUp(parent);
                }
            }

            private void MoveDown(int p)
            {
                var children = GetChildren(p);
                if (p > size || children.Item1 > size) return;
                if (children.Item2 < size && heap[children.Item1] > heap[children.Item2])
                {
                    Swap(children.Item1, children.Item2);
                }

                if (heap[p] > heap[children.Item1])
                {
                    Swap(p, children.Item1);
                    MoveDown(children.Item1);
                }
            }

            public void Add(int v)
            {
                heap[size++] = v;
                MoveUp(size - 1);
            }

            public int GetMin()
            {
                var r = heap[0];
                size--;
                heap[0] = heap[size];
                MoveDown(0);
                return r;
            }
        }
    }
}
