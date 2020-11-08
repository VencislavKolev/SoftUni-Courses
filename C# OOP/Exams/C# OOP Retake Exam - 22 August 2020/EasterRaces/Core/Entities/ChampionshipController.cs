using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_PARTICIPANTS = 3;

        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }
        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IDriver driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            this.raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }
        
        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < MIN_PARTICIPANTS)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));
            }

            List<IDriver> drivers = race.Drivers
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(race.Laps))
                .ToList();

            string firstDriver = drivers[0].Name;
            string secondDriver = drivers[1].Name;
            string thirdDriver = drivers[2].Name;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {firstDriver} wins {raceName} race.")
                .AppendLine($"Driver {secondDriver} is second in {raceName} race.")
                .AppendLine($"Driver {thirdDriver} is third in {raceName} race.");

            this.driverRepository.GetByName(firstDriver).WinRace();
            this.raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
        //public void NumberOfWinsPerDriver()
        //{
        //    var drivers = this.driverRepository.GetAll();
        //    foreach (var driver in drivers)
        //    {
        //        Console.WriteLine(driver.NumberOfWins);
        //    }
        //}
    }
}
