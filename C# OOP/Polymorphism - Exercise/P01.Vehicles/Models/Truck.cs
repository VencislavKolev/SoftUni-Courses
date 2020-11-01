
namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIRCON_INCREASE = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKilometer)
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

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * 0.95);
        }
    }
}
