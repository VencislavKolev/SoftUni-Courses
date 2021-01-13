using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniORM
{
    // TODO: Create your ChangeTracker class here.
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntites;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entites)
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntites = CloneEntities(entites);
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntites.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        public void Add(T item)
        {
            this.added.Add(item);
        }
        public void Remove(T item)
        {
            this.removed.Add(item);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            List<T> modifiedEntities = new List<T>();

            PropertyInfo[] primaryKeys = typeof(T)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (T proxyEntity in this.AllEntities)
            {
                Object[] primaryKeyValues = GetPrimatyKeyValues(primaryKeys, proxyEntity).ToArray();

                T entity = dbSet.Entities
                    .Single(e => GetPrimatyKeyValues(primaryKeys, proxyEntity)
                    .SequenceEqual(primaryKeys));

                bool isModified = IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }
            return modifiedEntities;
        }
        private static bool IsModified(T proxiEntity, T entity)
        {
            IEnumerable<PropertyInfo> monitoredProperties = typeof(T)
                 .GetProperties()
                 .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            PropertyInfo[] modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(proxiEntity), pi.GetValue(entity)))
                .ToArray();

            return modifiedProperties.Any();
        }
        private static IEnumerable<object> GetPrimatyKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }

        private static List<T> CloneEntities(IEnumerable<T> entites)
        {
            List<T> clonedEntities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (T entity in entites)
            {
                T clonedEntity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }
    }
}