
namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int backpackCapacity = 100;
        public Backpack()
            : base(backpackCapacity)
        {
        }
    }
}
