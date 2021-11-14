using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using EventAggregatorPattern;
using EventAggregatorPattern.Implementation;
using Xunit;


namespace EventAggregatorTest
{
    public class EventAggregatorTest
    {
        private EventAggregator _eventAggregator;


        public EventAggregatorTest()
        {
            _eventAggregator = new EventAggregator();
        }

        [Fact]
        public void publish_nulldata_throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => { _eventAggregator.Publish(null); });
        }

        [Fact]
        public void publish_data_with_empty_dictionary_returns_false()
        {
            string dataToPublish = "some value";
            var expectedResult = _eventAggregator.Publish(dataToPublish);
            Assert.False(expectedResult);
        }

        [Fact]
        public void publish_data_with_stringevent_returns_true()
        {
            string dataToPublish = "some value";
            _eventAggregator.EventDictionary.Add("string", new Event());
            var expectedResult = _eventAggregator.Publish(dataToPublish);
            Assert.True(expectedResult);

        }

        [Fact]
        public void publish_EventTypeNotFound_returns_false()
        {
            string dataToPublish = "some value";
            _eventAggregator.EventDictionary.Add("int",new Event());
            var expectedResult = _eventAggregator.Publish(dataToPublish);
            Assert.False(expectedResult);
        }

        [Fact]
        public void subscribe_with_NullCalbackAction_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(()=>_eventAggregator.Subscribe<string>(null));
        }

        [Fact]
        public void subscribe_with_StringCalbackAction_Returns_True()
        {
            var expectedResult = _eventAggregator.Subscribe<string>(OnStringAction);
            Assert.True(expectedResult);
        }

        [Fact]
        public void subscribe_and_pulish_calls_callbackmethod()
        {
            string dataToPublish = "some value";
            _eventAggregator.EventDictionary.Add("string", new Event());
            var expectedSubscriptionResult = _eventAggregator.Subscribe<string>(OnStringAction);
            var expectedPublishResult = _eventAggregator.Publish(dataToPublish);
            Assert.True(expectedSubscriptionResult);
            Assert.True(expectedPublishResult);
        }

        [Fact]
        public void UnSubscribe_with_NullCalbackAction_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => _eventAggregator.UnSubscribe<string>(null));
        }

        [Fact]
        public void UnSubscribe_with_StringCalbackAction_Returns_True()
        {
            _eventAggregator.EventDictionary.Add("string", new Event());
            var expectedSubscriptionResult = _eventAggregator.Subscribe<string>(OnStringAction);
            var expectedResult = _eventAggregator.UnSubscribe<string>(OnStringAction);
            Assert.True(expectedSubscriptionResult);
            Assert.True(expectedResult);
        }

        public void OnStringAction(object value)
        {
            Assert.Equal("some value", value);
        }
    }
}
