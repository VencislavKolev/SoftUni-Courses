﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace MiniORM
{
    // TODO: Create your DbSet class here.
    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();

            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }
        public int Count => this.Entities.Count;
        public bool IsReadOnly => this.Entities.IsReadOnly;
        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }
            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }
        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }

            bool removedSuccessfully = this.Entities.Remove(item);
            if (removedSuccessfully)
            {
                this.ChangeTracker.Remove(item);
            }
            return removedSuccessfully;
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                this.Remove(entity);
            }
        }
        public void Clear()
        {
            while (this.Entities.Any())
            {
                TEntity entity = this.Entities.First();
                this.Remove(entity);
            }
        }
        public bool Contains(TEntity entity)
        {
            return this.Entities.Contains(entity);
        }
        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            this.Entities.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}