using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventAggregatorPattern.Implementation;
using Xunit;

namespace EventAggregatorTest
{
    public class EventTest
    {
        private Event _eventToPublish;
        public EventTest()
        {
            _eventToPublish = new Event();
        }

        [Fact] 
        public void publish_WithNullCallbackAction_DoesNothing()
        {
            _eventToPublish.Publish("some value");
        }

        [Fact]
        public void CheckIfSubscriptionsExists_ifnot_returns_false()
        {
            var expectedResult = _eventToPublish.CheckIfSubscriptionsExists();
            Assert.False(expectedResult);
        }

        [Fact]
        public void CheckIfSubscriptionsExists_ifexists_returns_true()
        {
            _eventToPublish.CallbackActions += (object obj) => { };
            var expectedResult = _eventToPublish.CheckIfSubscriptionsExists();
            Assert.True(expectedResult);
            _eventToPublish.CallbackActions -= (object obj) => { };
        }
    }
}
