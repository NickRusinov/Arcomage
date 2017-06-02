using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x04, "Create user state index migration")]
    public class CreateUserStateIndexMigration : Migration
    {
        public override void Up()
        {
            Create.Index().OnTable("user").InSchema("public")
                .OnColumn("state").Ascending();
        }

        public override void Down()
        {
            Delete.Index().OnTable("user").InSchema("public")
                .OnColumn("state");
        }
    }
}
