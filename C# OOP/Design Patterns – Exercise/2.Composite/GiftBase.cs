
namespace _2.Composite
{
    public abstract class GiftBase
    {
        public GiftBase(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        protected string Name { get; set; }
        protected int Price { get; set; }

        public abstract int CalculateTotalPrice();
    }
}
