using System;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MiniORM
{
    // TODO: Create your DbContext class here.
    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;
        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        public void SaveChanges()
        {
            Object[] dbSets = this.dbSetProperties
                .Select(kvp => kvp.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<Object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(entity => !IsObjectValid(entity))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in{dbSet.GetType().Name}!");
                }
            }

            using (new ConnectionManager(connection))
            {
                using (SqlTransaction transaction = this.connection.StartTransaction())
                {
                    foreach (Object dbSet in dbSets)
                    {
                        Type dbSetType = dbSet
                            .GetType()
                            .GetGenericArguments()
                            .First();

                        MethodInfo persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetType);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {

                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
           where TEntity : class, new()
        {
            string tableName = this.GetTableName(typeof(TEntity));

            string[] columns = this.connection
                .FetchColumnNames(tableName)
                .ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            TEntity[] modifiedEntities = dbSet.ChangeTracker
                .GetModifiedEntities(dbSet)
                .ToArray();
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }
    }
}