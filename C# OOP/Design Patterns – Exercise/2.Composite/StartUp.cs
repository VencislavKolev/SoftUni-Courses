using System;

namespace _2.Composite
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("iPhone 12", 999);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompsiteGift rootBox = new CompsiteGift("RootBox", 0);
            SingleGift truckToy = new SingleGift("Truck", 289);
            SingleGift plainToy = new SingleGift("Plain", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            CompsiteGift childBox = new CompsiteGift("ChildBox", 0);
            SingleGift soldierToy = new SingleGift("Soldier", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);
            Console.WriteLine($"Total price for the composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
