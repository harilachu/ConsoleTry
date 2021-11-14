using System;

namespace EventAggregatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventAggregator eventAggregator = new EventAggregator();
            Publisher pub = new Publisher(eventAggregator);
            Subscriber sub = new Subscriber(eventAggregator);

            pub.PublishMessage("Get the Value");

            Message message = new Message("Set the Value");
            pub.PublishMessage(message);

            try
            {
                pub.PublishMessage(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
