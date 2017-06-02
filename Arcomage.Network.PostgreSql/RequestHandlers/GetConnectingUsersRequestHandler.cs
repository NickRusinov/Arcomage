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
    public class GetConnectingUsersRequestHandler : IAsyncRequestHandler<GetConnectingUsersRequest, IEnumerable<User>>
    {
        private readonly NpgsqlTransaction transaction;

        public GetConnectingUsersRequestHandler(NpgsqlTransaction transaction)
        {
            this.transaction = transaction;
        }

        public async Task<IEnumerable<User>> Handle(GetConnectingUsersRequest message)
        {
            var userCollection = await transaction.Connection.QueryAsync<User>(
                "SELECT * FROM public.user \n" +
                "WHERE state = @State",
                new { State = UserState.Connecting }, transaction);

            return userCollection.ToList();
        }
    }
}
