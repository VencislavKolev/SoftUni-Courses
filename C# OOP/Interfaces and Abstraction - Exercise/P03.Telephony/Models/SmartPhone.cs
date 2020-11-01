using System.Linq;
using P03.Telephony.Contracts;
using P03.Telephony.Exceptions;

namespace P03.Telephony.Models
{
    public class SmartPhone : ICallable, IBrowseable
    {
        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidURLMessage();
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }
            return $"Calling... {number}";
        }
    }
}
