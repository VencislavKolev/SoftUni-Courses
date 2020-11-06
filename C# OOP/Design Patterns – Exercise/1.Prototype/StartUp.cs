using System;

namespace _1.Prototype
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();
            menu["BLT"] = new Sandwich("Wheat", "Bacon", "Lettuce", "Tomato");
            menu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            Sandwich bltSandwich1 = menu["BLT"].Clone() as Sandwich;
            Sandwich pbjSandwich1 = menu["PB&J"].Clone() as Sandwich;
            Sandwich turkeySandwich1 = menu["Turkey"].Clone() as Sandwich;
        }
    }
}
