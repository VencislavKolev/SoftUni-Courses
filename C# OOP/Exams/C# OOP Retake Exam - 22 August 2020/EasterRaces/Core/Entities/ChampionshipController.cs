using System;
using System.Linq;
using System.Text;

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<ICar> carRepository;
        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new CarRepository();
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
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);

        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceRepository.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            IDriver[] topDrivers = race.Drivers
                .OrderByDescending(x => x.Car
                .CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            IDriver winner = topDrivers[0];
            winner.WinRace();
            //Console.WriteLine($"{string.Format(OutputMessages.DriverFirstPosition,winner.Name,raceName)}");

            IDriver secondPlace = topDrivers[1];
            //Console.WriteLine($"{string.Format(OutputMessages.DriverSecondPosition, secondPlace.Name, raceName)}");

            IDriver thirdPlace = topDrivers[2];
            //Console.WriteLine($"{string.Format(OutputMessages.DriverThirdPosition, thirdPlace.Name, raceName)}");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winner.Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, secondPlace.Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverThirdPosition, thirdPlace.Name, raceName));

            this.raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
