
using System.Collections.Generic;
using EasterRaces.Repositories.Contracts;

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
        public abstract bool Remove(T model);
        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll() => (IReadOnlyCollection<T>)this.models;
    }
}
