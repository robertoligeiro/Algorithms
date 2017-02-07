using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsReadAndWriteNoApiUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var rw = new ReadAndWrite();
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Write, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Write, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            ThreadPool.QueueUserWorkItem(rw.Read, 0);
            Console.ReadLine();
        }

        public class ReadAndWrite
        {
            public object rwLock = new object();
            public ManualResetEvent[] doneEvents = new ManualResetEvent[10];
            public int hasReaders = 0;

            public void Read(Object o)
            {
                int myId = 0;
                lock (rwLock)
                {
                    myId = this.hasReaders++;
                    doneEvents[myId] = new ManualResetEvent(false);
                }

                Random r = new Random();
                Console.WriteLine("Reader {0} reading...", myId);
                Thread.Sleep(r.Next(1000, 5000));
                Console.WriteLine("Reader {0} done!", myId);
                doneEvents[myId].Set();
            }

            public void Write(Object o)
            {
                lock (rwLock)
                {
                    if (this.hasReaders > 0)
                    {
                        Console.WriteLine("Writer waiting {0} Readers to finish...", this.hasReaders);
                        var h = new ManualResetEvent[this.hasReaders];
                        for (int i = 0; i < this.hasReaders; ++i)
                        {
                            h[i] = doneEvents[i];
                        }
                        WaitHandle.WaitAll(h);
                    }

                    this.hasReaders = 0;
                    Console.WriteLine("Writer done!");
                }
            }
        }
    }
}
