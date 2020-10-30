using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Schema;

namespace Parking
{
    public class Parking
    {
        private HashSet<Car> parkedCars;
        private int count;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.parkedCars = new HashSet<Car>();
        }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public int Count
        {
            get { return this.count; }
        }
        public void Add(Car car)
        {
            if (this.count < this.Capacity)
            {
                this.parkedCars.Add(car);
                this.count++;
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = this.parkedCars
                .FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove != null)
            {
                parkedCars.Remove(carToRemove);
                this.count--;
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (this.parkedCars.Any())
            {
                Car latestCar = this.parkedCars
                    .OrderByDescending(x => x.Year)
                    .FirstOrDefault();
                return latestCar;
            }
            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car searchedCar = this.parkedCars
                .FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (searchedCar != null)
            {
                return searchedCar;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            sb.Append(string.Join(Environment.NewLine, this.parkedCars));
            return sb.ToString().TrimEnd();
        }
    }
}
