using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesQueueWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            var r = q.Dequeue();
            q.Enqueue(4);
            q.Enqueue(5);
            r = q.Dequeue();
            r = q.Dequeue();
            r = q.Dequeue();
            r = q.Dequeue();
            r = q.Dequeue();
        }

        public class Queue
        {
            private Stack<int> se = new Stack<int>();
            private Stack<int> sd = new Stack<int>();
            public void Enqueue(int v)
            {
                se.Push(v);
            }
            public int Dequeue()
            {
                if (sd.Count == 0)
                {
                    while (se.Count > 0)
                    {
                        sd.Push(se.Pop());
                    }
                }
                if (sd.Count == 0) throw new Exception("empty queue");
                return sd.Pop();
            }
        }
    }
}
