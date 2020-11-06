
using System;

namespace _2.Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name,int price)
            :base(name,price)
        {

        }
        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} with the price {this.Price}");
            return this.Price;
        }
    }
}
