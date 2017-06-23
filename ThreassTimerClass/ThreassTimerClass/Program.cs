using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreassTimerClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Timer();
            t.AddTimer(new WorkItem() { id = 0 }, 10000);
            t.AddTimer(new WorkItem() { id = 1 }, 1000);
            t.AddTimer(new WorkItem() { id = 2 }, 100);
            t.AddTimer(new WorkItem() { id = 3 }, 20000);
            t.AddTimer(new WorkItem() { id = 4 }, 1000);
            Thread.Sleep(12000);
            t.Cancel(0);
            t.Cancel(1);
            t.Cancel(2);
            t.Cancel(3);
            t.Cancel(4);
            Console.ReadKey();
        }

        public class Timer
        {
            private Dictionary<int, CancellationTokenSource> scheduler = new Dictionary<int, CancellationTokenSource>();
            private object lockScheduler = new object();
            private void ExecuteTask(WorkItem w, int timeToStart)
            {
                Console.WriteLine("WorkItem {0} ExecuteTask set timer {1} to start.", w.id, timeToStart);
                Thread.Sleep(timeToStart);
                Task t = null;
                lock (this.lockScheduler)
                {
                    if (scheduler.ContainsKey(w.id) && !scheduler[w.id].IsCancellationRequested)
                    {
                        var cancelationTokenSource = new CancellationTokenSource();
                        t = Task.Run(() => w.TaskRrun(cancelationTokenSource.Token));
                        scheduler[w.id] = cancelationTokenSource;
                    }
                }

                if (t != null)
                {
                    t.Wait();
                    lock (this.lockScheduler)
                    {
                        if (scheduler.ContainsKey(w.id)) scheduler.Remove(w.id);
                        Console.WriteLine("WorkItem {0} executed and removed from scheduler table", w.id);
                    }
                }
            }

            public void AddTimer(WorkItem w, int timeToStart)
            {
                lock (this.lockScheduler)
                {
                    if (scheduler.ContainsKey(w.id))
                    {
                        Console.WriteLine("WorkItem {0} already exists. Not added.", w.id);
                        return;
                    }
                    var t = Task.Run(() => this.ExecuteTask(w, timeToStart));
                    scheduler[w.id] = new CancellationTokenSource();
                    Console.WriteLine("WorkItem {0} added.", w.id);
                }
            }

            public void Cancel(int id)
            {
                lock (this.lockScheduler)
                {
                    if (!scheduler.ContainsKey(id))
                    {
                        Console.WriteLine("WorkItem {0} has finished execution, nothing to remove.", id);
                        return;
                    }
                    var cancelationToken = scheduler[id];
                    cancelationToken.Cancel();
                    Console.WriteLine("WorkItem {0} canceled.", id);
                }
            }
        }

        public class WorkItem
        {
            public int id { get; set; }
            public void TaskRrun(CancellationToken ct)
            {
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("WorkItem {0}, cancel requested, exit", id);
                    return;
                }
                var rand = new Random();
                var timer = rand.Next(1000, 10000);
                Console.WriteLine("Started WorkItem {0}, timer {1}", id, timer);
                Thread.Sleep(timer);
                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("WorkItem {0}, cancel requested, exit", id);
                    return;
                }
                Console.WriteLine("WorkItem {0} is DONE!", id);
            }
        }
    }
}
