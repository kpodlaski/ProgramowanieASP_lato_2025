namespace BrokerInformacji
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    class Broker
    {
        private ConcurrentDictionary<string, BlockingCollection<Message>> messageQueues = new();
        private ConcurrentDictionary<string, string> objectTypes = new();

        public void Register(string id, string type)
        {
            messageQueues.TryAdd(id, new BlockingCollection<Message>());
            objectTypes.TryAdd(id, type);
            Console.WriteLine($"[Broker] Registered {type}: {id}");
        }

        public void Unregister(string id)
        {
            messageQueues.TryRemove(id, out _);
            objectTypes.TryRemove(id, out _);
            Console.WriteLine($"[Broker] Unregistered: {id}");
        }

        public void SendMessage(Message msg)
        {
            if (messageQueues.TryGetValue(msg.ToId, out var queue))
            {
                queue.Add(msg);
            }
        }

        public BlockingCollection<Message>? GetQueue(string id)
        {
            return messageQueues.TryGetValue(id, out var queue) ? queue : null;
        }

        public List<string> GetObjectsByType(string type)
        {
            return objectTypes.Where(kv => kv.Value == type).Select(kv => kv.Key).ToList();
        }
    }

}
