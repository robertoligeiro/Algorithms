using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesQueueWithMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new QueueWithMax();
            q.Enqueue(6);
            q.Enqueue(9);
            var m = q.Max();
            q.Enqueue(3);
            q.Enqueue(8);
            m = q.Max();
            q.Enqueue(1);
            q.Enqueue(2);
            m = q.Max();
            q.Dequeue();
            m = q.Max();
            q.Dequeue();
            m = q.Max();
            q.Dequeue();
            m = q.Max();
            q.Dequeue();
            m = q.Max();
            q.Dequeue();
            m = q.Max();
            q.Dequeue();
            m = q.Max();
            q.Dequeue();
            m = q.Max();
        }

        public class QueueWithMax
        {
            private Queue<int> q = new Queue<int>();
            private LinkedList<int> d = new LinkedList<int>();
            public void Enqueue(int v)
            {
                q.Enqueue(v);
                while (d.Count > 0 && d.Last() < v)
                {
                    d.RemoveLast();
                }
                d.AddLast(v);
            }

            public int Dequeue()
            {
                if (q.Count == 0) throw new Exception("empty");
                var t = q.Dequeue();
                if (t == d.First())
                {
                    d.RemoveFirst();
                }
                return t;
            }

            public int Max()
            {
                if (d.Count == 0) throw new Exception("empty");
                return d.First();
            }
        }
    }
}
