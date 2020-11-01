using System;
using System.Collections.Generic;
using System.Text;

namespace P06.FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthdate;
            this.Food = 0;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
