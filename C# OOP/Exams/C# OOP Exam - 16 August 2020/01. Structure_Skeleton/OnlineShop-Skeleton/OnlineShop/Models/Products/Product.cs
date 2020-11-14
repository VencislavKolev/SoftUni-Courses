
using System;

using OnlineShop.Common.Constants;



namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private const int MIN_VALUE = 0;

        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerfeormance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }
        public int Id
        {
            get => this.id;
            private set
            {
                if (value <= MIN_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                this.model = value;
            }
        }
        public virtual decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= MIN_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }
        public virtual double OverallPerformance
        {
            get => this.overallPerfeormance;
            private set
            {
                if (value <= MIN_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.overallPerfeormance = value;
            }
        }
        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
