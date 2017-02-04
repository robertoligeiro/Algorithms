using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsSynchronizationTwoThreads
{
    class Program
    {
        public static int count;
        public static int countOdd = 0;
        public static int countEven = 0;
        public static AutoResetEvent waitHandleEven;
        public static AutoResetEvent waitHandleOdd;
        static void Main(string[] args)
        {
            waitHandleEven = new AutoResetEvent(true);
            waitHandleOdd = new AutoResetEvent(false);
            Thread thread1 = new Thread(new ThreadStart(ThreadOdd));
            Thread thread2 = new Thread(new ThreadStart(ThreadEven));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }

        public static void ThreadOdd()
        {
            for (int i = 1; i < 100; i += 2)
            {
                waitHandleEven.WaitOne();
                count = i;
                countOdd++;
                waitHandleOdd.Set();
            }
        }
        public static void ThreadEven()
        {
            for (int i = 2; i <= 100; i += 2)
            {
                waitHandleOdd.WaitOne();
                count = i;
                countEven++;
                waitHandleEven.Set();
            }
        }
    }
}
