using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsMultipleLocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => Executor(1));
            Task.Run(() => Executor(2));
            Task.Run(() => Executor(3));
            Task.Run(() => Executor(4));
            Task.Run(() => Executor(5));
            t.Wait();
        }

        public static object lock1 = new object();
        public static object lock2 = new object();

        public static void Executor(int id)
        {
            while (true)
            {
                lock (lock1)
                {
                    if (Monitor.TryEnter(lock2))
                    {
                        try
                        {
                            Console.WriteLine("Thread {0} Got both locks.", id);
                            var rand = new Random();
                            var time = rand.Next(500, 10000);
                            Console.WriteLine("Thread {0} starting work {1}.", id, time);
                            Thread.Sleep(time);
                            Console.WriteLine("Thread {0} done {1}.", id, time);
                        }
                        finally
                        {
                            Monitor.Exit(lock2);
                        }
                    }
                }
            }
        }
    }
}
