using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
   public class Car
    {
        public Car(string model,string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; private set; }
        public string Color { get; private set; }
    }
}
