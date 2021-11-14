using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorPattern.Implementation;
using EventAggregatorPattern.Interfaces;

namespace EventAggregatorPattern
{
    public class EventAggregator : IEventAggregator
    {
        public Dictionary<string, IEvent<object>> EventDictionary { get; set; }

        public EventAggregator()
        {
            this.EventDictionary = new Dictionary<string, IEvent<object>>();
        }

        public bool Publish(object dataToPublish)
        {
            if (dataToPublish == null)
                throw new ArgumentNullException("dataToPublish cannot be null");
            if (EventDictionary.Count == 0)
                return false;

            try
            {
                var eventToPublish = EventDictionary[dataToPublish.GetType().Name.ToLower()];
                eventToPublish.Publish(dataToPublish);
            }
            catch (KeyNotFoundException e)
            {
                return false;
            }
            
            return true;
        }

        public bool Subscribe<T>(Action<object> callbackAction)
        {
            if(callbackAction==null)
                throw new ArgumentNullException("callbackAction cannot be null");

            
            var typename = typeof(T).Name.ToLower();

            if (!EventDictionary.ContainsKey(typename))
            {
                var eventToSubscribe = new Event();
                eventToSubscribe.Subscribe(callbackAction);
                EventDictionary.Add(typeof(T).Name.ToLower(), eventToSubscribe);
            }
            else
                EventDictionary[typename].Subscribe(callbackAction);

            return true;
        }

        public bool UnSubscribe<T>(Action<object> callbackAction)
        {
            if (callbackAction == null)
                throw new ArgumentNullException("callbackAction cannot be null");

            var typename = typeof(T).Name.ToLower();

            if (!EventDictionary.ContainsKey(typename))
            {
                return false;
            }
            else
            {
                var eventToUnSubscribe = EventDictionary[typename];
                eventToUnSubscribe.UnSubscribe(callbackAction);
            }

            return true;
        }
    }
}
