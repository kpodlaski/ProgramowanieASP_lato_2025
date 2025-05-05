using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleThreads
{
    internal class SimpleThreads
    {
        int counter = 0;
        public void InstanceMethod()
        {
            int a = 1;
            Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");
            for (int i=0; i<30000; i++)
            {
                lock (this) { 
                    counter = counter*a +1;
                }
                //Console.WriteLine("A" + i);
            }
            

            Console.WriteLine(
                "The instance method called by the worker thread has ended. "+counter);
        }
    }

   
}
