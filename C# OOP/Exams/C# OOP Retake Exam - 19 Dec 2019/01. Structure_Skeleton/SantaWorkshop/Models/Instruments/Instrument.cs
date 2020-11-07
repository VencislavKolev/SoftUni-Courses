
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private const int INSTRUMENT_DECREASE = 10;
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get => this.power;
            private set
            {
                this.power = value > 0 ? value : 0;
                //if (value < 0)
                //{
                //    this.power = 0;
                //}
                //this.power = value;
            }
        }

        public bool IsBroken()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= INSTRUMENT_DECREASE;
        }
    }
}
