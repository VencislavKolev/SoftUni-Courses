
using System;
using System.Collections.Generic;

namespace _2.Composite
{
    public class CompsiteGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;
        public CompsiteGift(string name, int price)
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;

            Console.WriteLine($"{this.Name} contains the following products with prices:");
            foreach (GiftBase gift in this.gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }
            return totalPrice;
        }

    }
}
