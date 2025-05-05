namespace BrokerInformacji
{
    using System;
    using System.Threading;

    class Client
    {
        private string id;
        private Broker broker;
        private string desiredBook;
        private Thread thread;

        public Client(string id, Broker broker, string book)
        {
            this.id = id;
            this.broker = broker;
            this.desiredBook = book;
            broker.Register(id, "Client");

            thread = new Thread(Run);
            thread.Start();
        }

        void Run()
        {
            var warehouses = broker.GetObjectsByType("Warehouse");
            foreach (var wid in warehouses)
            {
                broker.SendMessage(new Message(id, wid, $"QUERY:{desiredBook}"));
            }

            var queue = broker.GetQueue(id);
            decimal minPrice = decimal.MaxValue;
            string? bestWarehouse = null;

            var offersReceived = 0;
            while (offersReceived < warehouses.Count)
            {
                var msg = queue.Take();
                if (msg.Content.StartsWith("OFFER:"))
                {
                    var parts = msg.Content.Split(':');
                    var title = parts[1];
                    var price = decimal.Parse(parts[2]);
                    Console.WriteLine($"[Client {id}] Got offer for '{title}' from {msg.FromId} at ${price}");

                    if (price < minPrice)
                    {
                        minPrice = price;
                        bestWarehouse = msg.FromId;
                    }

                    offersReceived++;
                }
            }

            if (bestWarehouse != null)
            {
                broker.SendMessage(new Message(id, bestWarehouse, $"BUY:{desiredBook}"));
            }

            var soldMsg = queue.Take();
            if (soldMsg.Content.StartsWith("SOLD:"))
            {
                Console.WriteLine($"[Client {id}] Bought {desiredBook} from {soldMsg.FromId}");
            }
        }
    }

}
