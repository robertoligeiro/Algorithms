using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsThreadPool
{
    class Program
    {
        public static int[] val;
        static void Main(string[] args)
        {
            val = new int[100];
            ManualResetEvent[] doneEvents = new ManualResetEvent[10];
            int index = 0;
            for (int i = 0; i < 100; i = i + 10)
            {
                doneEvents[index] = new ManualResetEvent(false);
                var t = new ThreadCounter() { _doneEvent = doneEvents[index] };
                ThreadPool.QueueUserWorkItem(t.ThreadPoolCallback, i);
                index++;
            }

            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("main thread is done..");
            Console.ReadKey();
        }

        public class ThreadCounter
        {
            public ManualResetEvent _doneEvent { get; set; }
            public void ThreadPoolCallback(Object threadContext)
            {
                int i = (int)threadContext;
                for (int c = i; c < i + 10; ++c)
                {
                    val[c] = c;
                    Console.WriteLine(c);
                }
                Console.WriteLine("Done: " + i);
                _doneEvent.Set();
            }
        }
    }
}
