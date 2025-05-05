namespace SimpleThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleThreads  threadJob = new SimpleThreads();

            Thread[] InstanceCaller = new Thread[10];
            for (int k = 0; k < 10; k++)
            {
                InstanceCaller[k] = new(new ThreadStart(threadJob.InstanceMethod));
            }
            for (int k = 0; k < 10; k++) { 
            // Start the thread.
                InstanceCaller[k].Start();
            } 
        }
    }
}
