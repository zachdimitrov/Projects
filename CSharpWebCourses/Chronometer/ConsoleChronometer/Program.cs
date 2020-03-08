using System;

namespace ConsoleChronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chr = new Chronometer();
            Console.WriteLine("Use one of the following commands:\n\r[start] [stop] [lap] [laps] [time] [reset] [exit]");
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "start":
                        chr.Start();
                        break;
                    case "time":
                        Console.WriteLine(chr.GetTime);
                        break;
                    case "stop":
                        chr.Stop();
                        Console.WriteLine(chr.GetTime);
                        break;
                    case "lap":
                        Console.WriteLine(chr.Lap());
                        break;
                    case "laps":
                        Console.WriteLine(chr.getLaps());
                        break;
                    case "reset":
                        chr.Reset();
                        break;
                    default: 
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
    }
}
