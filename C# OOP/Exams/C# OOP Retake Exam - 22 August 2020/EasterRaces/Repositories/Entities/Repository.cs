
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;
        public Repository()
        {
            this.models = new List<T>();
        }
        public abstract void Add(T model);
        //{
        //    this.models.Add(model);
        //}
        public abstract bool Remove(T model);
        //{
        //    return this.models.Remove(model);
        //}
        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll() => (IReadOnlyCollection<T>)this.models;
    }
}
