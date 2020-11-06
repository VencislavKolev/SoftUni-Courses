
namespace _3.Template
{
    public class Sourdough : Bread
    {
        public Sourdough()
        {

        }
        public override void Bake()
        {
            System.Console.WriteLine($"Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            System.Console.WriteLine("Gathering the Ingredients for Sourdough Bread.");
        }
    }
}
