using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorPattern.Interfaces;

namespace EventAggregatorPattern.Implementation
{
    public class Event: IEvent<object>
    {
        public Action<object> CallbackActions { get; set; }
        public void Publish(object dataToPublish)
        {
            if (CheckIfSubscriptionsExists())
                CallbackActions.Invoke(dataToPublish);
        }

        public void Subscribe(Action<object> callbackAction)
        {
            CallbackActions += callbackAction;
        }

        public void UnSubscribe(Action<object> callbackAction)
        {
            CallbackActions -= callbackAction;
        }

        public bool CheckIfSubscriptionsExists()
        {
            if (CallbackActions != null && CallbackActions.GetInvocationList().Length > 0)
                return true;
            return false;
        }
    }
}
