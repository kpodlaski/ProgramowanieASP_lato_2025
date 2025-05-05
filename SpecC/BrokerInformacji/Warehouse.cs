namespace BrokerInformacji
{
    using System.Collections.Generic;
    using System.Threading;

    class Warehouse
    {
        private string id;
        private Broker broker;
        private Dictionary<string, decimal> books = new();
        private Thread thread;

        public Warehouse(string id, Broker broker)
        {
            this.id = id;
            this.broker = broker;
            books["C# Book"] = 50.0m;
            books["Python Book"] = 40.0m;
            broker.Register(id, "Warehouse");

            thread = new Thread(Run);
            thread.Start();
        }

        void Run()
        {
            var queue = broker.GetQueue(id);
            foreach (var msg in queue.GetConsumingEnumerable())
            {
                if (msg.Content.StartsWith("QUERY:"))
                {
                    var title = msg.Content.Substring(6);
                    if (books.TryGetValue(title, out decimal price))
                    {
                        broker.SendMessage(new Message(id, msg.FromId, $"OFFER:{title}:{price}"));
                    }
                }
                else if (msg.Content.StartsWith("BUY:"))
                {
                    var title = msg.Content.Substring(4);
                    if (books.ContainsKey(title))
                    {
                        broker.SendMessage(new Message(id, msg.FromId, $"SOLD:{title}"));
                    }
                }
            }
        }
    }

}
