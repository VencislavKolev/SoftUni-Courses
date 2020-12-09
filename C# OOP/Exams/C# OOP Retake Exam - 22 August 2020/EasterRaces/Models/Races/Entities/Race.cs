
using System;
using System.Linq;
using System.Collections.Generic;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;
        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string excMsg = string.Format(ExceptionMessages.InvalidName, value, 5);
                    throw new ArgumentException(excMsg);
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)this.drivers;

        //TODO check ArgumentNullExceptions
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(IDriver), ExceptionMessages.DriverInvalid);
            }
            else if (driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            else if (this.Drivers.Any(x => x.Name == driver.Name))
            {
                string excMsg = string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name);
                throw new ArgumentNullException(nameof(IDriver), excMsg);
            }
            this.drivers.Add(driver);
        }
    }
}
