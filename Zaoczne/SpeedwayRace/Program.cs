namespace SpeedwayRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpeedwayRace race = new SpeedwayRace(4, 30000);
            race.StartRace(new string[] { "Adam", "Marian", "Zenon", "Kamil" });
        }
    }
}
