
namespace P04.WildFarm.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        double WeightMultiplier { get; }
        string ProduceSound();
        void Feed(IFood food);
    }
}
