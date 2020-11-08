
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MIN_NAME_LEN = 5;
        private const int MIN_LAPS = 1;

        private string name;
        private int laps;
        private ICollection<IDriver> drivers;
        public Race(string name,int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MIN_NAME_LEN)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_NAME_LEN));
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MIN_LAPS)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }
            else if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            else if (this.drivers.Contains(driver))
            {
                //"" paramName
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded));
            }
            else
            {
                this.drivers.Add(driver);
            }
        }
    }
}
