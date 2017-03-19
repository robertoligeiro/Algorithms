using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                if (input == "think")
                {
                    //run copy file async, don't block main thread
                    //best implementation, light way, don't use Threads, but Tasks/await.
                    DoThink();

                    //-- since ThinkSynchronous isn't async, 
                    // the only way for it to not block main is using Task.Run().
                    // or creating a thread, but threads are costy.
                    //Task.Run(ThinkSynchronous);

                    //--the same goes to this one, where ThinkSynchronous is called 
                    //in parallel with another method,
                    //but because I used Task.Run, it won't block main.
                    //Task.Run(() => DoThinkWithParallelInvoke()); 

                    // it called this way, it will block main.
                    // that's because Parallel.Invoke calls a synchronous method.
                    //DoThinkWithParallelInvoke();
                }
                else
                {
                    Console.WriteLine($"you said: {input}");
                }
            }
        }

        public static async Task DoThink()
        {
            await DoAsync();
            Console.WriteLine("done thinking..");
        }

        public static void DoThinkWithParallelInvoke()
        {
            Parallel.Invoke(() => ThinkSynchronous(), () => Console.WriteLine("done thinking nada.."));
        }

        public static void ThinkSynchronous()
        {
            
            for (int i = 0; i < 1000000000; ++i)
            {
            }
            Console.WriteLine("done thinking..");
        }

        // copy file on disk asynchronous
        public static async Task DoAsync()
        {
            string UserDirectory = @"C:\Users\romarque\Pictures\Camera Roll\";

            using (StreamReader SourceReader = File.OpenText(UserDirectory + "t.mp4"))
            {
                using (StreamWriter DestinationWriter = File.CreateText(UserDirectory + "CopiedFile.txt"))
                {
                    await CopyFilesAsync(SourceReader, DestinationWriter);
                }
            }
        }

        public static async Task CopyFilesAsync(StreamReader Source, StreamWriter Destination)
        {
            char[] buffer = new char[0x1000];
            int numRead;
            while ((numRead = await Source.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                await Destination.WriteAsync(buffer, 0, numRead);
            }
        }
    }
}
