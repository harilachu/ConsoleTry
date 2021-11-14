using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern.Interfaces
{
    public interface IEvent<T> where T : class 
    {
        Action<T> CallbackActions { get; set; }
        void Publish(T dataToPublish);
        void Subscribe(Action<T> callbackAction);
        void UnSubscribe(Action<T> callbackAction);
        bool CheckIfSubscriptionsExists();
    }
}
