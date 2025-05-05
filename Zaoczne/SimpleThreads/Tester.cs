using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleThreads
{
    internal class Tester
    {
        Counter c;
        public Tester(Counter c)
        {
            this.c = c;
        }

        public void test()
        {
            int value;
            while (true)
            {
                lock (c)
                {
                    value = c.counter;
                }
                if (value%2 == 1)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("tested value \t=" + value);
                    Console.WriteLine("counter value \t=" + c.counter);
                    Environment.Exit(11);
                }
            }
        }

        public static void Main()
        {
            Counter counter = new Counter();
            Tester tester = new Tester(counter);
            Thread testThread = new(new ThreadStart(tester.test));
            Thread countThread = new(new ThreadStart(counter.count));

            countThread.Start();
            testThread.Start();
            

        }

    }
}
