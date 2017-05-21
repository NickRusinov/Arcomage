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

        public Task<IEnumerable<User>> Handle(GetConnectingUsersRequest message)
        {
            return transaction.Connection.QueryAsync<User>(
                "SELECT * FROM User \n" +
                "WHERE State = @State",
                new { State = UserState.Connecting }, transaction);
        }
    }
}
