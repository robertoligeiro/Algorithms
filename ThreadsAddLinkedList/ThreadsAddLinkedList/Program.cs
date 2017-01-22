using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAddLinkedList
{
    class Program
    {
        public static ConcurrentList concurrentList = new ConcurrentList();
        static void Main(string[] args)
        {

            //concurrentList.AddValue(3);
            //concurrentList.AddValue(1);
            //concurrentList.AddValue(6);
            //concurrentList.AddValue(4);
            //concurrentList.AddValue(7);

            var numThreads = 30;
            var threads = new Thread[numThreads];
            // Start workers.
            for (var i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(AddToList));
                threads[i].Start(i);
            }

            for (var i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            concurrentList.PrintList();
            Console.ReadKey();
        }

        static void AddToList(object p1)
        {
            int id = (int)p1;
            Random r = new Random();
            for (int j = 0; j < 50; ++j)
            {
                concurrentList.AddValue(r.Next(0, 1000), id);
            }
        }
        public class Node
        {
            public int val;
            public Node next;
            public Node prev;
            public int thread;
            public Mutex nodeLock = new Mutex();
            public Node(int v)
            {
                val = v;
            }
        }
        public class ConcurrentList
        {
            private Node head = new Node(0);

            public void AddValue(int v, int th)
            {
                var nNode = new Node(v) { thread = th};

                //empty list
                head.nodeLock.WaitOne();
                if (head.next == null)
                {
                    head.next = nNode;
                    head.nodeLock.ReleaseMutex();
                    return;
                }

                // get mutext first node
                head.next.nodeLock.WaitOne();
                var it = head.next;

                // add at the head
                if (it.val >= nNode.val)
                {
                    head.next = nNode;

                    nNode.next = it;
                    it.prev = nNode;
                    it.nodeLock.ReleaseMutex();
                    head.nodeLock.ReleaseMutex();
                    return;
                }

                head.nodeLock.ReleaseMutex();

                while (it.next != null)
                {
                    var next = it.next;
                    if (it.val <= nNode.val && next.val >= nNode.val)
                    {
                        it.next = nNode;
                        nNode.next = next;
                        nNode.prev = it;
                        next.prev = nNode;
                        it.nodeLock.ReleaseMutex();
                        return;
                    }
                    else
                    {
                        var prev = it;
                        next.nodeLock.WaitOne();
                        it = next;
                        prev.nodeLock.ReleaseMutex();
                        
                    }
                }

                it.next = nNode;
                nNode.prev = it;
                it.nodeLock.ReleaseMutex();
                return;
            }

            public void PrintList()
            {
                head.nodeLock.WaitOne();
                var it = head.next;
                StringBuilder resp = new StringBuilder("list: ");
                while (it != null)
                {
                    if (it.next != null && it.next.val < it.val)
                    {
                        throw new Exception("sort error...");
                    }

                    resp.Append(it.val +",");
                    it = it.next;
                }
                head.nodeLock.ReleaseMutex();
                Console.WriteLine(resp);
            }
        }

    }
}
