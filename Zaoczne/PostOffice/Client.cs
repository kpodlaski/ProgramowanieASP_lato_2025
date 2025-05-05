using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice
{
    internal class Client
    {
        public int ID {  get; private set; }
        private static int lastID = 0;
        private Post post;

        public Client(Post post)
        {
            this.post = post;
            lock (post)
            {
                this.ID = lastID++;
            }
        }

        private void approachClerk(Clerk clerk)
        {
            clerk.ServiceMe(this);
        }

        public void InPost()
        {
            Console.WriteLine("Client {0} enter the post office", this.ID);
            Clerk c = post.getFreeClerk();
            approachClerk (c);
            post.setFreeClerk(c);
            Console.WriteLine("Client {0} leave the post office", this.ID);
        }

    }
}
