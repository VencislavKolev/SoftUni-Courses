
namespace P01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIRCON_INCREASE = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKilometer)
            : base(fuelQuantity, fuelConsumptionPerKilometer)
        {

        }

        public override double FuelConsumptionPerKilometer
        {
            get
            {
                return base.FuelConsumptionPerKilometer;
            }
            protected set
            {
                base.FuelConsumptionPerKilometer = value + AIRCON_INCREASE;
            }
        }
    }
}
