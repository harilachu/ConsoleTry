using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern
{
    public class Publisher
    {
        public IEventAggregator EventAggregator { get; }

        public Publisher(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }

        public void PublishMessage(object message)
        {
            var result = EventAggregator.Publish(message);
            if(result)
                Console.WriteLine($"Published message: {message}");
        }
    }
}
