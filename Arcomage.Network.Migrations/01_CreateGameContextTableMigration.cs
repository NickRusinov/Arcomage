using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x01, "Create game context table migration")]
    public class CreateGameContextTableMigration : Migration
    {
        public override void Up()
        {
            Create.Table("GameContext")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().Identity()
                .WithColumn("JobId").AsString(32).NotNullable()
                .WithColumn("Version").AsInt32().NotNullable()
                .WithColumn("State").AsString(32).NotNullable()
                .WithColumn("StartedDate").AsDateTime().Nullable()
                .WithColumn("FinishedDate").AsDateTime().Nullable()
                .WithColumn("CancelledDate").AsDateTime().Nullable()
                .WithColumn("Game").AsBinary().NotNullable()
                .WithColumn("FirstUser").AsGuid().NotNullable().ForeignKey("User", "Id")
                .WithColumn("SecondUser").AsGuid().NotNullable().ForeignKey("User", "Id")
                .WithColumn("Timestamp").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("GameContext");
        }
    }
}
