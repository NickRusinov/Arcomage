using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x02, "Create user table migration")]
    public class CreateUserTableMigration : Migration
    {
        public override void Up()
        {
            Create.Table("user").InSchema("public")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("state").AsInt32().NotNullable()
                .WithColumn("timestamp").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("user").InSchema("public");
        }
    }
}
