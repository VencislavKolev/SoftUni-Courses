
namespace P02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double WITH_PEOPLE_INCREASE = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
        {

        }
    }
}
