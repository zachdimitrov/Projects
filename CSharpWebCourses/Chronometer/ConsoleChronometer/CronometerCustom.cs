using ConsoleChronometer.Contracts;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleChronometer
{
    public class CronometerCustom : IChronometer
    {
        private long milliseconds;
        private long elapsed;
        private bool isRunning;

        public CronometerCustom()
        {
            this.elapsed = 0;
            this.Laps = new List<string>();
        }

        public string GetTime => timeConvert(milliseconds);

        private string timeConvert(long time)
        {
            return $"{time / 60000:D2}:{time / 1000:D2}.{(time % 1000):D4}";
        }

        public string getLaps()
        {
            if (Laps.Count == 0)
            {
                return "Laps: No laps!";
            }

            StringBuilder str = new StringBuilder();
            str.AppendLine("Laps:");
            int count = 0;
            foreach (var item in Laps)
            {
                count++;
                str.AppendLine($"{count}. {item}");
            }

            return str.ToString().TrimEnd();
        }

        public List<string> Laps { get; }

        public string Lap()
        {
            this.elapsed = milliseconds - elapsed;
            string lapString = timeConvert(elapsed);
            Laps.Add(lapString);
            return lapString;
        }

        public void Reset()
        {
            this.milliseconds = 0;
        }

        public void Start()
        {
            this.isRunning = true;
            Task.Run(() =>
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1);
                    milliseconds++;
                }
            });
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
