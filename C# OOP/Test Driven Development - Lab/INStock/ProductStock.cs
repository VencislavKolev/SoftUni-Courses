
using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly HashSet<string> productLabels;
        private readonly List<IProduct> productByIndex;
        private readonly Dictionary<string, IProduct> productByLabel;
        private readonly Dictionary<int, List<IProduct>> productByQuantity;
        private readonly SortedDictionary<decimal, List<IProduct>> productsSortedByPrice;
        public ProductStock()
        {
            this.productLabels = new HashSet<string>();
            this.productByIndex = new List<IProduct>();
            this.productByLabel = new Dictionary<string, IProduct>();
            this.productByQuantity = new Dictionary<int, List<IProduct>>();
            this.productsSortedByPrice = new SortedDictionary<decimal, List<IProduct>>(Comparer<decimal>.Create((first, second) => second.CompareTo(first)));
        }

        public int Count => this.productByIndex.Count;

        public void Add(IProduct product)
        {
            this.ValidateNullProduct(product);

            if (this.productLabels.Contains(product.Label))
            {
                throw new ArgumentException($"A product with '{product.Label}' label already exists.");
            }

            this.InitializeCollections(product);

            this.productLabels.Add(product.Label);
            this.productByIndex.Add(product);
            this.productByLabel[product.Label] = product;
            this.productByQuantity[product.Quantity].Add(product);
            this.productsSortedByPrice[product.Price].Add(product);
        }
        public bool Remove(IProduct product)
        {
            this.ValidateNullProduct(product);

            string label = product.Label;

            if (!this.productLabels.Contains(label))
            {
                return false;
            }

            this.productByIndex.RemoveAll(pr => pr.Label == label);

            this.RemoveProductFromCollection(product);

            return true;
        }

        public bool Contains(IProduct product)
        {
            this.ValidateNullProduct(product);
            return this.productLabels.Contains(product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Product index does not exist.");
            }
            return this.productByIndex[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentException("Product label cannot be null.");
            }
            if (!this.productLabels.Contains(label))
            {
                throw new ArgumentException($"Product with '{label}' label could not be found.");
            }
            return this.productByLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productsSortedByPrice.Any())
            {
                throw new InvalidOperationException("ProductStock is empty.");
            }
            var mostExpensiveProducts = this.productsSortedByPrice.First();

            IProduct firstAddedMostExpensiveProduct = mostExpensiveProducts.Value.First();
            return firstAddedMostExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            decimal priceAsDecimal = (decimal)price;
            if (!this.productsSortedByPrice.ContainsKey(priceAsDecimal))
            {
                return Enumerable.Empty<IProduct>();
            }
            return this.productsSortedByPrice[priceAsDecimal];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (!this.productByQuantity.ContainsKey(quantity))
            {
                return Enumerable.Empty<IProduct>();
            }
            return this.productByQuantity[quantity];
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            List<IProduct> result = new List<IProduct>();

            foreach (var (price, products) in this.productsSortedByPrice)
            {
                double priceAsDouble = (double)price;
                if (lo <= priceAsDouble && priceAsDouble <= hi)
                {
                    result.AddRange(products);
                }

                if (priceAsDouble < lo)
                {
                    break;
                }
            }
            return result;
        }
        public IProduct this[int index]
        {
            get => this.Find(index);
            set
            {
                this.ValidateNullProduct(value);

                this.InitializeCollections(this.Find(index));

                this.RemoveProductFromCollection(value);

                this.productByIndex[index] = value;
            }
        }


        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.productByIndex.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product cannot be null.");
            }
        }
        private void InitializeCollections(IProduct product)
        {
            if (!this.productByQuantity.ContainsKey(product.Quantity))
            {
                this.productByQuantity[product.Quantity] = new List<IProduct>();
            }
            if (!this.productsSortedByPrice.ContainsKey(product.Price))
            {
                this.productsSortedByPrice[product.Price] = new List<IProduct>();
            }
        }
        private void RemoveProductFromCollection(IProduct product)
        {
            string label = product.Label;

            this.productLabels.Remove(label);
            this.productByLabel.Remove(label);

            var allWithProductQuantity = this.productByQuantity[product.Quantity];
            allWithProductQuantity.RemoveAll(pr => pr.Label == label);

            var allWithProductPrice = this.productsSortedByPrice[product.Price];
            allWithProductPrice.RemoveAll(pr => pr.Label == label);
        }
    }
}
