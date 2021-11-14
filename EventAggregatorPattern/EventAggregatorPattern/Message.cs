using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorPattern
{
    public class Message
    {
        private string _message;

        public Message(string message)
        {
            this._message = message;
        }

        public override string ToString()
        {
            return _message;
        }
    }
}
