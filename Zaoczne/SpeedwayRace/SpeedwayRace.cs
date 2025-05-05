using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedwayRace
{
    internal class SpeedwayRace
    {
        public double Distance { get; private set; }
        private Barrier StartLine;
        private Barrier EndLine;
        private int numberOfRacers;
        private List<Racer> racers = new List<Racer>();
        private long startTime;

        public SpeedwayRace(int nRacers, double distance)
        {
            this.numberOfRacers = nRacers;
            this.Distance = distance;
            StartLine = new Barrier(this.numberOfRacers, initRace);
            EndLine = new Barrier(this.numberOfRacers, showResults);
        }

        private void initRace(Barrier obj)
        {
            startTime = DateTime.Now.Ticks;
            Console.WriteLine("Start!!!");
        }

        private void showResults(Barrier obj)
        {
            Console.WriteLine(" WYNIKI :");
            foreach (Racer r in racers)
            {
                long t = r.Time - startTime;
                Console.WriteLine(r.Name + " " + t + " [ticks]");
            }
        }

        public void StartRace(String[] names)
        {
            foreach (String name in names)
            {
                Racer r = new Racer(name, this, this.StartLine, this.EndLine);
                racers.Add(r);
                r.DoRace();
            }
        }
    }
}
