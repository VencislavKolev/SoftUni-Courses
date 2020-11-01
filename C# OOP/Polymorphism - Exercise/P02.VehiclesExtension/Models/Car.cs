
namespace P02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double AIRCON_INCREASE = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
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
