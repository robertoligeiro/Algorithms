using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewPcSkytap
{
    class Program
    {
        public static QueueThreadSafe q = new QueueThreadSafe();
        public static void ThreadOdd()
        {
            var r = q.Get();
        }
        public static void ThreadEven()
        {
            q.Put(10);
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(ThreadOdd));
            Thread thread2 = new Thread(new ThreadStart(ThreadEven));

            Thread thread3 = new Thread(new ThreadStart(ThreadOdd));
            Thread thread4 = new Thread(new ThreadStart(ThreadOdd));
            Thread thread22 = new Thread(new ThreadStart(ThreadEven));
            Thread thread222 = new Thread(new ThreadStart(ThreadEven));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
//            Thread.Sleep(15000);
            thread3.Start();
            thread4.Start();
            thread22.Start();
            thread222.Start();
            //var r = GetOddNumbers(new List<int>() { -3,-2,3,3 });

            //var n6 = new Node() { val = 6 };
            //var n3 = new Node() { val = 3 };
            //var n7 = new Node() { val = 7 };
            //var n1 = new Node() { val = 1 };
            //var n5 = new Node() { val = 5 };
            //var n4 = new Node() { val = 4 };

            //n6.left = n3;
            //n6.right = n7;
            //n3.left = n1;
            //n3.right = n5;
            //n5.left = n4;

            //var r6 = n6.CountDescendants();
            //var r3 = n3.CountDescendants();
            //var r7 = n7.CountDescendants();
            //var r1 = n1.CountDescendants();
            //var r5 = n5.CountDescendants();
            //var r4 = n4.CountDescendants();

        }

        public static List<int> GetOddNumbers(List<int> numbers)
        {
            var resp = new List<int>();
            foreach (var i in numbers)
            {
                if (i % 2 != 0)
                {
                    resp.Add(i);
                }
            }
            return resp;
        }

        public class Node
        {
            public int val { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
            public int CountDescendants()
            {
                return CountDescendants(this.left) + CountDescendants(this.right);
            }

            private int CountDescendants(Node n)
            {
                if (n == null) return 0;
                return CountDescendants(n.left) + CountDescendants(n.right) + 1;
            }
        }

        public class QueueThreadSafe
        {
            private Queue<int> q = new Queue<int>();
            private Object mutex = new Object();
            private AutoResetEvent waitHandle = new AutoResetEvent(true);

            public void Put(int val)
            {
                lock (mutex)
                {
                    q.Enqueue(val);
                    if (q.Count == 1)
                    {
                        this.waitHandle.Set();
                    }
                }
            }

            public int Get()
            {
                lock (mutex)
                {
                    if (q.Count > 0)
                    {
                        return q.Dequeue();
                    }
                }

                this.waitHandle.WaitOne();
                return this.Get();
            }
        }
    }
}
