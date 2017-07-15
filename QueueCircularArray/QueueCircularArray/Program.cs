using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueCircularArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue(3);
            q.Enqueue(0); //q-> 0
            q.Enqueue(1); //q-> 0,1
            var d = q.Dequeue(); // q->X,1
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(7);
        }

        public class Queue
        {
            private int size;
            private int used;
            private int[] q;
            private int start = 0;
            private int tail = 0;
            public Queue(int s)
            {
                size = s;
                q = new int[size];
            }

            public void Enqueue(int v)
            {
                if (used == size)
                {
                    size *= 2;
                    var nqueue = new int[size];
                    Array.Copy(q, start, nqueue, 0, q.Length - start);
                    if (start >= tail)
                    {
                        Array.Copy(q, 0, nqueue, q.Length - start , tail);
                    }
                    q = nqueue;
                    tail = used;
                    start = 0;
                }
                q[tail] = v;
                tail++;
                tail %= size;
                used++;
            }

            public int Dequeue()
            {
                if (used > 0)
                {
                    var r = q[start];
                    start++;
                    start %= size;
                    used--;
                    return r;
                }
                throw new ArgumentOutOfRangeException("no elements...");
            }
        }
    }
}
