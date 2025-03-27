using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleThreads
{
    internal class SimpleThread
    {
        private static int i  = 0;
        // The method that will be called when the thread is started.
        public void InstanceMethod()
        {
            int c = 0;
            for (i = 0; i < 3000; i++)
            {
                c += 1;
                Console.WriteLine("A" + c);
            }
            Console.WriteLine("A" + c);
        }

        public static void StaticMethod()
        {
            int c = 0;
            for (i = 0; i < 3000; i++)
            {
                c += 1;
                Console.WriteLine("B" + c);
            }
            Console.WriteLine("B" + c);
        }

        public static void Main()
        {
            SimpleThread serverObject = new SimpleThread();

            // Create the thread object, passing in the
            // serverObject.InstanceMethod method using a
            // ThreadStart delegate.
            Thread InstanceCaller = new(new ThreadStart(serverObject.InstanceMethod));

            // Start the thread.
            InstanceCaller.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new InstanceCaller thread.");

            // Create the thread object, passing in the
            // serverObject.StaticMethod method using a
            // ThreadStart delegate.
            Thread StaticCaller = new(new ThreadStart(SimpleThread.StaticMethod));

            // Start the thread.
            StaticCaller.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new StaticCaller thread.");
        }
    }
}
