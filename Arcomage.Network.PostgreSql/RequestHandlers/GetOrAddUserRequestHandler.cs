using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using Dapper;
using MediatR;
using Npgsql;

namespace Arcomage.Network.PostgreSql.RequestHandlers
{
    public class GetOrAddUserRequestHandler : IAsyncRequestHandler<GetOrAddUserRequest, User>
    {
        private readonly NpgsqlTransaction transaction;

        public GetOrAddUserRequestHandler(NpgsqlTransaction transaction)
        {
            this.transaction = transaction;
        }

        public Task<User> Handle(GetOrAddUserRequest message)
        {
            return transaction.Connection.QuerySingleAsync<User>(
                "INSERT INTO User \n" +
                "(Id, Name, Timestamp) \n" +
                "VALUES (@Id, @Name, DEFAULT) \n" +
                "ON CONFLICT (Name) DO NOTHING \n" +
                "RETURNING *",
                new { Id = Guid.NewGuid(), Name = message.Name }, transaction);
        }
    }
}
