
namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MIN_HP = 400;
        private const int MAX_HP = 600;
        public MuscleCar(string model, int horsePower, double cubicCentimeters) 
            : base(model, horsePower, cubicCentimeters)
        {

        }

        public override int HorsePower 
        { 

        }

        public override double CubicCentimeters => base.CubicCentimeters;
    }
}
