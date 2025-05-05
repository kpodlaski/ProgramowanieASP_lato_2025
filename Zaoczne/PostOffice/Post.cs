
namespace PostOffice
{
    public class Post
    {
        private Queue<Clerk> freeClerks = new Queue<Clerk>();
        private Semaphore semaphore;
        public Post(int number_of_clerks)
        {
            semaphore = new Semaphore(0, number_of_clerks);
            for (int i = 0; i < number_of_clerks; i++)
            {
                Clerk c = new Clerk(this);
            }
            Console.WriteLine("Post is Open!!!");

        }
        internal Clerk getFreeClerk()
        {
            semaphore.WaitOne();
            Clerk c = null;
            lock (freeClerks)
            {
                c = freeClerks.Dequeue();
            }
            return c;

        }

        internal void setFreeClerk(Clerk c)
        {
            lock (freeClerks)
            {
                freeClerks.Enqueue(c);
            }
            semaphore.Release();
        }
    }
}