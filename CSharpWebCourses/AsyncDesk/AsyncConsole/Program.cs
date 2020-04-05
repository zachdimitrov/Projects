using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsole
{
    static class Data
    {
        public static int A;
    }

    class Program
    {
        static void Main()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Thread thread2 = new Thread(() => MyThread2Main(sw));
            thread2.Priority = ThreadPriority.Highest;
            thread2.Start();

            Thread thread3 = new Thread(() => MyThread3Main(sw));
            thread3.Start();

            Thread thread4 = new Thread(() => MyThread4Main(sw));
            thread4.Start();

            /*
            Task.Run(() =>
            {
                Data.A++;
                int n = int.Parse(Console.ReadLine());
                int k = NumberOfPrimeNumbers(0, n);
                Console.WriteLine($"Thread 1 calculated: [{0}-{n}] are {k}.\r\n");
                Console.WriteLine($"Elapsed {sw.Elapsed}");
            });

            while (true)
            {
                string line = Console.ReadLine();
                Console.WriteLine(line);
                if (line == "exit")
                {
                    return;
                }
            }
            */
        }

        private static void MyThread2Main(Stopwatch sw)
        {
            int n = 400900;
            Console.WriteLine($"Thread 2 calculated: [{0}-{n}] are {NumberOfPrimeNumbers(1, n)}");
            Console.WriteLine($"Elapsed {sw.Elapsed}");
        }

        private static void MyThread3Main(Stopwatch sw)
        {
            int n = 500000;
            Console.WriteLine($"Thread 3 calculated: [{0}-{n}] are {NumberOfPrimeNumbers(1, n)}");
            Console.WriteLine($"Elapsed {sw.Elapsed}");
        }

        private static void MyThread4Main(Stopwatch sw)
        {
            int n = 500100;
            Console.WriteLine($"Thread 4 calculated: [{0}-{n}] are {NumberOfPrimeNumbers(1, n)}");
            Console.WriteLine($"Elapsed {sw.Elapsed}");
        }

        private static int NumberOfPrimeNumbers(int from, int to)
        {
            int count = 0;
            for (int i = from; i <= to; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(to); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime) { count++; }
            }

            return count;
        }
    }
}
