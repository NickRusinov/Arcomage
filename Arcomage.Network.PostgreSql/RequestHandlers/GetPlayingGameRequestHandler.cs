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
    public class GetPlayingGameRequestHandler : IAsyncRequestHandler<GetPlayingGameRequest, GameContext>
    {
        private readonly NpgsqlTransaction transaction;

        public GetPlayingGameRequestHandler(NpgsqlTransaction transaction)
        {
            this.transaction = transaction;
        }

        public async Task<GameContext> Handle(GetPlayingGameRequest message)
        {
            var query = await transaction.Connection.QueryAsync<GameContext, User, User, GameContext>(
                "SELECT * FROM GameContext gc \n" +
                "LEFT OUTER JOIN User u1 ON gc.FirstUser = u1.Id \n" +
                "LEFT OUTER JOIN User u2 ON gc.SecondUser = u2.Id \n" +
                "WHERE gc.State = @State AND (gc.FirstUser = @UserId OR gc.SecondUser = @UserId)",
                (gc, u1, u2) => { gc.FirstUser = u1; gc.SecondUser = u2; return gc; },
                new { State = GameState.Started, UserId = message.User.Id }, transaction);

            return query.SingleOrDefault();
        }
    }
}
