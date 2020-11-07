
using System.Linq;
using System.Collections.Generic;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private ICollection<IDwarf> dwarves;

        public DwarfRepository()
        {
            this.dwarves = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => (IReadOnlyCollection<IDwarf>)this.dwarves;

        public void Add(IDwarf model)
        {
            this.dwarves.Add(model);
        }
        public bool Remove(IDwarf model)
        {
            return this.dwarves.Remove(model);
        }
        public IDwarf FindByName(string name)
        {
            return this.dwarves.FirstOrDefault(x => x.Name == name);
        }

    }
}
