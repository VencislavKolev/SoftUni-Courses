
namespace _3.Template
{
    public class TwelveGrain : Bread
    {
        public TwelveGrain()
        {

        }
        public override void Bake()
        {
            System.Console.WriteLine($"Baking the 12-Grain Bread. (25 minutes)");
        }

        public override void MixIngredients()
        {
            System.Console.WriteLine("Gathering the Ingredients for 12-Grain Bread.");
        }
    }
}
