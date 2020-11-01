using P03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.ShoppingSpree
{
    public class Product
    {
        private const decimal COST_MIN_VALUE = 0m;

        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameMessage);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value < COST_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyMessage);
                }
                this.cost = value;
            }
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
