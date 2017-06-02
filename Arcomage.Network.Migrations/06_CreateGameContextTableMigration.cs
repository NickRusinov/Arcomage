using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x06, "Create gamecontext table migration")]
    public class CreateGameContextTableMigration : Migration
    {
        public override void Up()
        {
            Create.Table("gamecontext").InSchema("public")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("jobid").AsAnsiString(64).Nullable()
                .WithColumn("version").AsInt32().NotNullable()
                .WithColumn("state").AsInt32().NotNullable()
                .WithColumn("starteddate").AsDateTime().Nullable()
                .WithColumn("finisheddate").AsDateTime().Nullable()
                .WithColumn("cancelleddate").AsDateTime().Nullable()
                .WithColumn("game").AsBinary().NotNullable()
                .WithColumn("firstuserid").AsGuid().NotNullable().ForeignKey("user", "id")
                .WithColumn("seconduserid").AsGuid().NotNullable().ForeignKey("user", "id")
                .WithColumn("timestamp").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("gamecontext").InSchema("public");
        }
    }
}
