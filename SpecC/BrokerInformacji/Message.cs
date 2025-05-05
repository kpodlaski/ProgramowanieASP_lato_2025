using System;
namespace BrokerInformacji
{
    class Message
    {
        public string FromId { get; }
        public string ToId { get; }
        public string Content { get; }

        public Message(string from, string to, string content)
        {
            FromId = from;
            ToId = to;
            Content = content;
        }
    }

}