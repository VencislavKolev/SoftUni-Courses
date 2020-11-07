
namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int START_ENERGY = 100;
        public HappyDwarf(string name)
            : base(name, START_ENERGY)
        {

        }

        public override void Work()
        {
            this.Energy -= base.DwarfWork;
        }
    }
}
