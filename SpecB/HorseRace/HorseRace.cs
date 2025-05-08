using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    internal class HorseRace
    {
        List<Horse> horses = new List<Horse>();
        internal Barrier StartLine, FinishLine;
        long startTime;
        internal double Distance;

        internal HorseRace(int horseCount)
        {
            Distance = 3000;
            StartLine = new Barrier(horseCount, (a)=> {
                startTime = DateTime.Now.Ticks;
                Console.WriteLine("Start the race !!!!");
            });
            FinishLine = new Barrier(horseCount, (a) =>
            {
                showResults();
            });
            for (int i = 0; i < horseCount; i++)
            {
                Horse h = new Horse(this);
                horses.Add(h);
            }
        }

        private void showResults()
        {
            horses.Sort();
            Console.WriteLine("Race ended");
            Console.WriteLine("=============");
            Console.WriteLine("Race Results:");
            foreach (Horse h in horses)
            {
                Console.WriteLine("Horse {0} with time: {1}", h.horseId, h.finishTime - startTime);
            }
            Console.WriteLine("=============");
        }

        public void StartRace()
        {
            Console.WriteLine("Horses getting Ready");
            foreach (Horse h in horses)
            {
                h.Start();
            }
        }
    }
}
