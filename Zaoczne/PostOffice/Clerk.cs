using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice
{
    internal class Clerk
    {
        private int ID { get; set; }
        private static int lastID = 0;
        private Post post;
        private Random random;

        public Clerk(Post post)
        {
            this.post = post;
            this.random = new Random();
            lock (post)
            {
                this.ID = lastID++;
            }
            post.setFreeClerk(this);
        }
        internal void ServiceMe(Client client)
        {
            int timeOfService = random.Next(500);
            Console.WriteLine("Clerk {0} is servicing client {1}", this.ID, client.ID);
            Thread.Sleep(timeOfService);
            Console.WriteLine("Clerk {0} is now free", this.ID);
        }
    }
}
