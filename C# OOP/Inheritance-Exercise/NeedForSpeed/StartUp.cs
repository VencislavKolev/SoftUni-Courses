using System;
namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
    

            var motor = new Motorcycle(100, 2.5);
            motor.Drive(100);
            Console.WriteLine(motor.Fuel); //1.25

            var motorRace = new RaceMotorcycle(50, 10);
            motorRace.Drive(100);
            Console.WriteLine(motorRace.Fuel); //2

            var motorCross = new CrossMotorcycle(50, 2.5);
            motorCross.Drive(100);
            Console.WriteLine(motorCross.Fuel); //1.25

            //Car car = new Car(100, 3);
            //car.Drive(100);
            //Console.WriteLine(car.Fuel);

            var car2 = new FamilyCar(100, 3);
            car2.Drive(100);
            Console.WriteLine(car2.Fuel); //0

            var sportCar = new SportCar(50, 10);
            sportCar.Drive(50);
            Console.WriteLine(sportCar.Fuel); //5

            Car car = new Car(100, 3);
            car.Drive(100);
            Console.WriteLine(car.Fuel); //0
        }
    }
}
