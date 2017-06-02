using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x03, "Create user name index migration")]
    public class CreateUserNameIndexMigration : Migration
    {
        public override void Up()
        {
            Create.Index().OnTable("user").InSchema("public")
                .OnColumn("name").Unique();
        }

        public override void Down()
        {
            Delete.Index().OnTable("user").InSchema("public")
                .OnColumn("name");
        }
    }
}
