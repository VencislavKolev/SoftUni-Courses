using P03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.ShoppingSpree
{
    public class Person
    {
        private const decimal MONEY_MIN_VALUE = 0m;

        private string name;
        private decimal money;
        private List<Product> bag;
        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
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
        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < MONEY_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyMessage);
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.InsufficientMoneyExceptionMessage, this.Name, product.Name));
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
        }
        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
