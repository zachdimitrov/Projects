using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncRace
{
    class Program
    {
        static void Main()
        {
            object lockObject = new object();
            int a = 0;
            List<Thread> threads = new List<Thread>();
            var SW = Stopwatch.StartNew();

            for (int i = 0; i <= 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    for (int j = 0; j < 10000000; j++)
                    {
                       lock(lockObject)
                       {
                            a++;
                       }
                    }
                });

                foreach (var th in threads)
                {
                    th.Join();
                }

                threads.Add(thread);
                thread.Start();
            }


            //// faster solution - no concurency
            //for (int i = 0; i <= 10; i++)
            //{
            //    for (int j = 0; j < 100000000; j++)
            //    {
            //        a++;
            //    }
            //}

            Console.WriteLine(a);
            Console.WriteLine(SW.Elapsed);
        }
    }
}
