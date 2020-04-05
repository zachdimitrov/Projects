using ConsoleChronometer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChronometer
{
    public class Chronometer : IChronometer
    {
        private DateTime start;
        private DateTime prevTime;
        private string time;
        private bool started = false;

        public Chronometer()
        {
            this.time = "00:00.0000000";
            this.Laps = new List<string>();
        }
 
        public string GetTime 
        { 
            get 
            {
                if (started)
                {
                    this.time = (DateTime.Now - start).ToString("mm':'ss'.'fffffff");
                }
                return this.time; 
            } 
        }

        public List<string> Laps { get; }

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

        public string Lap()
        {
            string lapTime = (DateTime.Now - this.prevTime).ToString("mm':'ss'.'fffffff");
            this.prevTime = DateTime.Now;
            Laps.Add(lapTime);
            return lapTime;
        }

        public void Reset()
        {
            if (this.started)
            {
                this.start = DateTime.Now;
            }
            else
            {

                this.start = DateTime.Now;
            }
        }

        public void Start()
        {
            if (!this.started)
            {
                this.started = true;
                this.start = DateTime.Now;
                this.prevTime = start;
            }
        }

        public void Stop()
        {
            if (started)
            {
                this.started = false;
                this.time = (DateTime.Now - start).ToString("mm':'ss'.'fffffff");
            }
        }
    }
}
