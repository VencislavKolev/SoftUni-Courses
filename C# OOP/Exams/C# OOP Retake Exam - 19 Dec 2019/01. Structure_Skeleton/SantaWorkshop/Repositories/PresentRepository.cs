
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private ICollection<IPresent> presents;
        public PresentRepository()
        {
            this.presents = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models => (IReadOnlyCollection<IPresent>)this.presents;

        public void Add(IPresent model)
        {
            this.presents.Add(model);
        }
        public bool Remove(IPresent model)
        {
            return this.presents.Remove(model);
        }
        public IPresent FindByName(string name)
        {
            return this.presents.FirstOrDefault(x => x.Name == name);
        }
    }
}
