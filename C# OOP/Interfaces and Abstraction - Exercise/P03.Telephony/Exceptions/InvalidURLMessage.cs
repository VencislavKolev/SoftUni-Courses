using System;

namespace P03.Telephony.Exceptions
{
    public class InvalidURLMessage: Exception
    {
        private const string EXC_MSG = "Invalid URL!";
        public InvalidURLMessage()
            :base(EXC_MSG)
        {

        }

        public InvalidURLMessage(string message)
            : base(message)
        {
        }
    }
}
