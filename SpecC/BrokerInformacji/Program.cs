namespace BrokerInformacji
{
    using System.Threading;

    class Program
    {
        static void Main()
        {
            var broker = new Broker();

            var warehouse1 = new Warehouse("W1", broker);
            var warehouse2 = new Warehouse("W2", broker);

            var client1 = new Client("C1", broker, "Python Book");

            Thread.Sleep(5000); // Wait for threads to complete (simple way)
        }
    }

}
