using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Npgsql;

namespace Arcomage.Network.PostgreSql.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly NpgsqlTransaction transaction;

        protected readonly IMapper mapper;

        protected readonly string tableName;

        protected readonly string columnNames;

        protected readonly string columnValues;
        
        public Repository(NpgsqlTransaction transaction, IMapper mapper)
        {
            this.transaction = transaction;
            this.mapper = mapper;
            tableName = typeof(T).Name;
            columnNames = string.Join(", ", typeof(T).GetProperties().Select(p => p.Name));
            columnValues = string.Join(", ", typeof(T).GetProperties().Select(p => p.Name != "Timestamp" ? "@" + p.Name : "DEFAULT"));
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var entity = await transaction.Connection.QuerySingleOrDefaultAsync<T>(
                $"SELECT * FROM {tableName} \n" +
                $"WHERE Id = @Id", 
                new { Id = id }, transaction);

            return entity;
        }

        public virtual async Task<bool> DeleteById(Guid id)
        {
            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"DELETE FROM {tableName} \n" +
                $"WHERE Id = @Id",
                new { Id = id }, transaction);

            return rowAffect != 0;
        }

        public virtual async Task<bool> Add(T entity)
        {
            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"INSERT INTO {tableName} \n" +
                $"({columnNames}) \n" +
                $"VALUES ({columnValues})",
                entity, transaction);

            return rowAffect != 0;
        }

        public virtual async Task<bool> Save(T entity)
        {
            var rowAffect = await transaction.Connection.ExecuteAsync(
                $"INSERT INTO {tableName} \n" +
                $"({columnNames}) \n" +
                $"VALUES ({columnValues}) \n" +
                $"ON CONFLICT (Id) DO UPDATE \n" +
                $"SET ({columnNames}) = \n" +
                $"({columnValues})",
                entity, transaction);

            return rowAffect != 0;
        }

        public virtual async Task<bool> Update(T entity, Action<T> update)
        {
            var updateEntity = mapper.Map<T>(entity);

            while (true)
            {
                update.Invoke(updateEntity);

                var rowAffect = await transaction.Connection.ExecuteAsync(
                    $"UPDATE {tableName} \n" +
                    $"SET ({columnNames}) = \n" +
                    $"({columnValues}) \n" +
                    $"WHERE Id = @Id AND Timestamp = @Timestamp",
                    entity, transaction);

                if (rowAffect == 0)
                {
                    mapper.Map(updateEntity, entity);
                    return true;
                }
                
                updateEntity = await transaction.Connection.QuerySingleOrDefaultAsync<T>(
                    $"SELECT * FROM {tableName} \n" +
                    $"WHERE Id = @Id",
                    entity, transaction);

                if (updateEntity == null)
                {
                    mapper.Map(entity, entity);
                    return false;
                }
            }
        }
    }
}
