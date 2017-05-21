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
    public class GameContextRepository : Repository<GameContext>
    {
        public GameContextRepository(NpgsqlTransaction transaction, IMapper mapper)
            : base(transaction, mapper)
        {

        }

        public override async Task<GameContext> GetById(Guid id)
        {
            var query = await transaction.Connection.QueryAsync<GameContext, User, User, GameContext>(
                "SELECT * FROM GameContext gc \n" +
                "LEFT OUTER JOIN User u1 ON gc.FirstUser = u1.Id \n" +
                "LEFT OUTER JOIN User u2 ON gc.SecondUser = u2.Id \n" +
                "WHERE gc.Id = @Id",
                (gc, u1, u2) => { gc.FirstUser = u1; gc.SecondUser = u2; return gc; },
                new { Id = id }, transaction);

            return query.SingleOrDefault();
        }
    }
}
