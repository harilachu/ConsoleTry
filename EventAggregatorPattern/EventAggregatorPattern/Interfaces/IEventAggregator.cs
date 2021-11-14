using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorPattern.Interfaces;

namespace EventAggregatorPattern
{
    public interface IEventAggregator
    {
        Dictionary<string, IEvent<object>> EventDictionary { get; set; }
        bool Publish(object dataToPublish);
        bool Subscribe<T>(Action<object> callbackAction);
        bool UnSubscribe<T>(Action<object> callbackAction);
    }
}
