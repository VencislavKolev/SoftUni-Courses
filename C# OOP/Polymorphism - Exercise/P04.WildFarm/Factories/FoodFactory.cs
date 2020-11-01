

using P04.WildFarm.Models.Contracts;
using P04.WildFarm.Models.Food;

namespace P04.WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood ProduceFood(string name, int quantity)
        {
            IFood food = null;
            if (name == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (name == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (name == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (name == "Seeds")
            {
                food = new Seeds(quantity);
            }
            return food;
        }
    }
}
