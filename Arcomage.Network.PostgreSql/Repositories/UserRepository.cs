using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Arcomage.Network.PostgreSql.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(NpgsqlTransaction transaction) 
            : base(transaction)
        {

        }

        protected override void UpdateEntity(User entity, User dbEntity)
        {
            base.UpdateEntity(entity, dbEntity);
            entity.Name = dbEntity.Name;
            entity.State = dbEntity.State;
        }
    }
}
