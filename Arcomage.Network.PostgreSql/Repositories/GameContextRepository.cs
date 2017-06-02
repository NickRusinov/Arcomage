using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Arcomage.Network.PostgreSql.Repositories
{
    public class GameContextRepository : Repository<GameContext>
    {
        public GameContextRepository(NpgsqlTransaction transaction)
            : base(transaction)
        {

        }

        protected override void UpdateEntity(GameContext entity, GameContext dbEntity)
        {
            base.UpdateEntity(entity, dbEntity);
            entity.JobId = dbEntity.JobId;
            entity.State = dbEntity.State;
            entity.Version = dbEntity.Version;
            entity.Game = dbEntity.Game;
            entity.StartedDate = dbEntity.StartedDate;
            entity.FinishedDate = dbEntity.FinishedDate;
            entity.CancelledDate = dbEntity.CancelledDate;
            entity.FirstUserId = dbEntity.FirstUserId;
            entity.SecondUserId = dbEntity.SecondUserId;
        }

        public override async Task<GameContext> GetById(Guid id)
        {
            var query = await transaction.Connection.QueryAsync<GameContext, User, User, GameContext>(
                "SELECT * FROM public.gamecontext gc \n" +
                "LEFT OUTER JOIN public.user u1 ON gc.firstuserid = u1.id \n" +
                "LEFT OUTER JOIN public.user u2 ON gc.seconduserid = u2.id \n" +
                "WHERE gc.id = @Id",
                (gc, u1, u2) => { gc.FirstUser = u1; gc.SecondUser = u2; return gc; },
                new { Id = id }, transaction);

            return query.SingleOrDefault();
        }
    }
}
