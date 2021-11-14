using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern
{
    public class Subscriber
    {
        public IEventAggregator EventAggregator { get; }

        public Subscriber(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe<string>(OnMessageStringReceived);
            EventAggregator.Subscribe<Message>(OnMessageReceived);
        }

        public void OnMessageStringReceived(object message)
        {
            Console.WriteLine($"Received message: {message}");
        }

        public void OnMessageReceived(object message)
        {
            Console.WriteLine($"Received message: {message}");
        }
    }
}
