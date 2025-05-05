using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleThreads
{
    internal class Counter
    {
        public int counter = 0;
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
    }
}
