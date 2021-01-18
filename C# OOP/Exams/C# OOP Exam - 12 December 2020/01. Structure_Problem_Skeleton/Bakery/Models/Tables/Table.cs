
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Bakery.Utilities.Messages;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IDrink> drinkOrders;
        private readonly ICollection<IBakedFood> foodOrders;

        private int capacity;
        private int numberOfPeople;
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.drinkOrders = new List<IDrink>();
            this.foodOrders = new List<IBakedFood>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0) //<= check
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.numberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();

            this.IsReserved = false;
            this.numberOfPeople = 0;
        }


        public decimal GetBill()
        {
            decimal foodSum = this.foodOrders.Sum(x => x.Price);
            decimal drinkSum = this.drinkOrders.Sum(x => x.Price);
            decimal totalSum = this.Price + foodSum + drinkSum;

            return totalSum;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}")
              .AppendLine($"Type: {this.GetType().Name}")
              .AppendLine($"Capacity: {this.Capacity}")
              .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood foods)
        {
            this.foodOrders.Add(foods);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
