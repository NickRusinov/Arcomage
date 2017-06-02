using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x07, "Create gamecontext state index migration")]
    public class CreateGameContextStateIndexMigration : Migration
    {
        public override void Up()
        {
            Create.Index().OnTable("gamecontext").InSchema("public")
                .OnColumn("state").Ascending();
        }

        public override void Down()
        {
            Delete.Index().OnTable("gamecontext").InSchema("public")
                .OnColumn("state");
        }
    }
}
