namespace PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post(3);
            for (int i = 0; i < 30; i++)
            {
                Client c = new Client(post);
                Thread t = new(new ThreadStart(c.InPost));
                t.Start();
            }
        }
    }
}
