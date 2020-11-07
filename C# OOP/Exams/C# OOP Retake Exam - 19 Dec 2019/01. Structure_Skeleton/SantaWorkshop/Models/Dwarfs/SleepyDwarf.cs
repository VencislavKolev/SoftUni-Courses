
namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int START_ENERGY = 50;
        private const int EXTRA_WORK_ENERGY = 5;
        public SleepyDwarf(string name)
            : base(name, START_ENERGY)
        {

        }

        public override void Work()
        {
            this.Energy -= base.DwarfWork + EXTRA_WORK_ENERGY;
        }
    }
}
