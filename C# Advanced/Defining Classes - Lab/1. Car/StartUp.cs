﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Make = "VW",
                Model = "MK3",
                Year = 1992
            };

            Console.WriteLine($"Make: {car.Make}{Environment.NewLine}" +
                $"Model: {car.Model}{Environment.NewLine}" +
                $"Year: {car.Year}");
        }
    }
}

