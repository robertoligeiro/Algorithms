using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesCircularQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new Queue(2);
            q.EnQueue(0);
            q.EnQueue(1);
            q.EnQueue(2);
            q.EnQueue(3);
            var d = q.DeQueue();
            q.EnQueue(4);
            q.EnQueue(5);
            d = q.DeQueue();
            d = q.DeQueue();
            d = q.DeQueue();
            d = q.DeQueue();
            q.EnQueue(1);
            q.EnQueue(2);
            q.EnQueue(3);
            q.EnQueue(4);
            q.EnQueue(5);
            q.EnQueue(6);
            q.EnQueue(7);
            q.EnQueue(8);
            var s = q.size;
        }

        public class Queue
        {
            public int size { get; set; }
            private int head { get; set; }
            private int tail { get; set; }
            private int[] q { get; set; }

            public Queue(int size)
            {
                q = new int[size];
            }
            public int DeQueue()
            {
                if (size-- > 0)
                {
                    int t = q[head];
                    q[head] = -1;
                    head = (head + 1) % q.Length;
                    return t;
                }

                throw new Exception("queue is empty");
            }

            public void EnQueue(int val)
            {
                if (size == q.Length)
                {
                    var nQ = new int[q.Length * 2];
                    int startToEnd = q.Length - head;
                    Array.Copy(q, head, nQ, 0, startToEnd);
                    Array.Copy(q, 0, nQ, startToEnd, tail);
                    head = 0;
                    tail = size;
                    q = nQ;
                }
                size++;
                q[tail] = val;
                tail = (tail + 1) % q.Length;
            }
        }
    }
}
