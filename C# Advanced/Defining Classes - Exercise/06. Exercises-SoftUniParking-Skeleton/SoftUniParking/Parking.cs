using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }
        public int Count => this.cars.Count();
        //private class CarRegistrationNumberComparer : IEqualityComparer<Car>
        //{
        //    public bool Equals(Car x, Car y)
        //    {
        //        return x.RegistrationNumber.Equals(y.RegistrationNumber, StringComparison.InvariantCultureIgnoreCase);
        //    }

        //    public int GetHashCode(Car obj)
        //    {
        //        return obj.RegistrationNumber.GetHashCode();
        //    }
        //}
        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            else if (this.cars.Count >= this.capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!this.cars
                .Any(c => c.RegistrationNumber == registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars
                    .Remove(this.cars
                    .FirstOrDefault(c => c.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            //Func<Car, string, bool> filter = (car, regNumber) => car.RegistrationNumber == regNumber;
            foreach (var currRegNumber in registrationNumbers)
            {
                this.cars
                    .RemoveAll(x => x.RegistrationNumber == currRegNumber);
            }
        }
    }
}