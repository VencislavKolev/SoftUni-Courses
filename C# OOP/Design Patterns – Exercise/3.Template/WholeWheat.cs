
namespace _3.Template
{
   public class WholeWheat:Bread
    {
        public WholeWheat()
        {

        }
        public override void Bake()
        {
            System.Console.WriteLine($"Baking the WholeWheat Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            System.Console.WriteLine("Gathering the Ingredients for WholeWheat Bread.");
        }
    }
}
