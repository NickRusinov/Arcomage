using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Arcomage.Network.PostgreSql.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected static readonly string tableName;

        protected static readonly string columnNames;

        protected static readonly string columnValues;

        protected readonly NpgsqlTransaction transaction;

        static Repository()
        {
            var propertyArray = typeof(T).GetProperties()
                .Where(p => !typeof(Entity).IsAssignableFrom(p.PropertyType)).ToArray();

            var propertyNamesCollection = propertyArray
                .Select(p => p.Name.ToLower());
            var propertyValuesCollection = propertyArray
                .Select(p => p.Name != "Timestamp" ? "@" + p.Name : "DEFAULT");

            tableName = typeof(T).Name.ToLower();
            columnNames = string.Join(", ", propertyNamesCollection);
            columnValues = string.Join(", ", propertyValuesCollection);
        }

        protected Repository(NpgsqlTransaction transaction)
        {
            this.transaction = transaction;
        }
        
        protected virtual void UpdateEntity(T entity, T dbEntity)
        {
            entity.Id = dbEntity.Id;
            entity.Timestamp = dbEntity.Timestamp;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var entity = await transaction.Connection.QuerySingleOrDefaultAsync<T>(
                $"SELECT * FROM public.{tableName} \n" +
                $"WHERE id = @Id", 
                new { Id = id }, transaction);

            return entity;
        }

        public virtual async Task<bool> DeleteById(Guid id)
        {
            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"DELETE FROM public.{tableName} \n" +
                $"WHERE id = @Id",
                new { Id = id }, transaction);

            return rowAffect != 0;
        }

        public virtual async Task<bool> Add(T entity)
        {
            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"INSERT INTO public.{tableName} ({columnNames}) \n" +
                $"VALUES ({columnValues})",
                entity, transaction);

            return rowAffect != 0;
        }

        public virtual async Task<bool> Save(T entity)
        {
            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"INSERT INTO public.{tableName} ({columnNames}) \n" +
                $"VALUES ({columnValues}) \n" +
                $"ON CONFLICT (id) DO UPDATE \n" +
                $"SET ({columnNames}) = ({columnValues})",
                entity, transaction);

            return rowAffect != 0;
        }

        public virtual async Task<bool> Update(T entity, Action<T> update)
        {
            var updateEntity = await transaction.Connection.QuerySingleOrDefaultAsync<T>(
                $"SELECT * FROM public.{tableName} \n" +
                $"WHERE id = @Id \n" +
                $"FOR UPDATE",
                entity, transaction);

            UpdateEntity(entity, updateEntity);
            update.Invoke(entity);

            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"UPDATE public.{tableName} \n" +
                $"SET ({columnNames}) = ({columnValues}) \n" +
                $"WHERE id = @Id AND timestamp = @Timestamp",
                entity, transaction);

            return rowAffect != 0;
        }
    }
}
