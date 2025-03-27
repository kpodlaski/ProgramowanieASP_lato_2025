using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleThreads
{
    internal class Tester
    {
        EvenCounter ec;
        public Tester(EvenCounter ec) { this.ec = ec; }
        public void testParity()
        {
            //Console.WriteLine("Rozpoczynam testowanie!!");
            int t = 0;
            while (true)
            {
                lock (ec)
                {
                    t = ec.counter;
                }
                if (t % 2 == 1)
                {
                    Console.WriteLine("ERRROR " + ec.counter + "  t:" + t);
                    Environment.Exit(12);
                }
            }

        }
    }

    internal class EvenCounter
    {
        public int  counter = 0;

        public void count()
        {
            while (true)
            {
                lock (this)
                {
                    counter += 1;
                    counter += 1;
                }
            }
        }

        

        public static void Main()
        {
            EvenCounter ec = new EvenCounter();
            Tester tester = new Tester(ec);
            Thread count = new(new ThreadStart(ec.count));
            Thread test = new(new ThreadStart(tester.testParity));
            count.Start();
            test.Start();
            
        }
    }
}
