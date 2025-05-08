
namespace HorseRace
{
    internal class Horse: IComparable<Horse>
    {
        HorseRace race;
        internal long finishTime;
        Thread thread;
        internal int horseId;
        static int lastId =0;
        static Random rand = new Random();
        double vel, x;
        internal Horse(HorseRace hRace)
        {
            lock (rand)
            {
                horseId = lastId++;
                vel = 0.2+rand.NextDouble() * 3;
                x = 0;
            }
            this.race = hRace;
            thread = new Thread(new ThreadStart(run));
        }

        private void run()
        {
            Console.WriteLine("Horse {0} on start line", horseId);
            race.StartLine.SignalAndWait();
            while (x <= race.Distance)
            {
                x += vel;
            }
            finishTime = DateTime.Now.Ticks;
            race.FinishLine.SignalAndWait();
            Console.WriteLine("Horse {0} going out of the stadium", horseId);
        }

        internal void Start()
        {
            thread.Start();
        }

        public int CompareTo(Horse? other)
        {
            return long.Sign(finishTime - other.finishTime) ;
        }
    }
}