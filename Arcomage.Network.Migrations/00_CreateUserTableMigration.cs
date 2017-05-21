using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x00, "Create user table migration")]
    public class CreateUserTableMigration : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable().Unique()
                .WithColumn("State").AsString(32).NotNullable()
                .WithColumn("Timestamp").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
