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

        public async Task<User> Handle(GetOrAddUserRequest message)
        {
            return 
                await transaction.Connection.QuerySingleOrDefaultAsync<User>(
                    "SELECT * FROM public.user \n" +
                    "WHERE name = @Name",
                    new { Name = message.Name }, transaction) ??

                await transaction.Connection.QuerySingleOrDefaultAsync<User>(
                    "INSERT INTO public.user (id, name, state, timestamp) \n" +
                    "VALUES (@Id, @Name, @State, DEFAULT) \n" +
                    "ON CONFLICT (name) DO NOTHING RETURNING *",
                    new { Id = Guid.NewGuid(), Name = message.Name, State = UserState.None }, transaction);
        }
    }
}
