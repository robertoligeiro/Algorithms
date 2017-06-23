using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewQualtricsPhoneThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            var throttle = new Throttle();
            throttle.Add(new WorkItem());
            throttle.Add(new WorkItem());
            throttle.Add(new WorkItem());
            throttle.Add(new WorkItem());
            throttle.Add(new WorkItem());
            throttle.Add(new WorkItem());
            throttle.Add(new WorkItem());
            Console.ReadKey();
        }

        public class Throttle : ThreadPool
        {
            private AutoResetEvent waitTask;
            private object threadLock = new object();
            private Queue<WorkItem> tasks;

            public Throttle()
            {
                tasks = new Queue<WorkItem>();
                waitTask = new AutoResetEvent(false);
                Task.Run(() => ExecuteWorkItems());
            }
            public void Add(WorkItem workItem)
            {
                lock (threadLock)
                {
                    tasks.Enqueue(workItem);
                    if (tasks.Count == 1)
                    {
                        waitTask.Set();
                    }
                }
            }

            private void ExecuteWorkItems()
            {
                while (true)
                {
                    WorkItem taskToExecute = null;
                    lock (threadLock)
                    {
                        if (this.tasks.Count > 0)
                        {
                            taskToExecute = this.tasks.Dequeue();
                        }
                    }

                    if (taskToExecute == null)
                    {
                        waitTask.WaitOne();
                    }
                    else
                    {
                        base.Add(taskToExecute).Wait();
                    }
                }
            }
        }

        public class ThreadPool
        {
            protected Task Add(WorkItem workItem)
            {
                return Task.Run(() => workItem.TaskRrun());
            }
        }

        public class WorkItem
        {
            public void TaskRrun()
            {
                var rand = new Random();
                var timer = rand.Next(1000, 10000);
                Console.WriteLine("started, timer {0}", timer);
                Thread.Sleep(timer);
                Console.WriteLine("done, timer {0}", timer);
            }
        }
    }
}
