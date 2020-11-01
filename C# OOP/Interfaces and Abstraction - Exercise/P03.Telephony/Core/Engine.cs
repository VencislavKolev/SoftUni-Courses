using P03.Telephony.Models;
using P03.Telephony.Contracts;
using P03.Telephony.Exceptions;

namespace P03.Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private SmartPhone smartPhone;
        private StationaryPhone stationaryPhone;
        private Engine()
        {
            this.smartPhone = new SmartPhone();
            this.stationaryPhone = new StationaryPhone();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split();
            string[] sites = reader.ReadLine().Split();
            CallNumbers(phoneNumbers);
            BrowseSites(sites);
        }

        private void BrowseSites(string[] sites)
        {
            foreach (var site in sites)
            {
                try
                {
                    writer.WriteLine(smartPhone.Browse(site));
                }
                catch (InvalidURLMessage ium)
                {
                    writer.WriteLine(ium.Message);
                }
            }
        }

        private void CallNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        writer.WriteLine(smartPhone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ine)
                {
                    writer.WriteLine(ine.Message);
                }

            }
        }
    }
}
