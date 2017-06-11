using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x09, "Create quartz tables migration")]
    public class CreateQuartzTablesMigration : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("09_CreateQuartzTablesMigration.Up.sql");
        }

        public override void Down()
        {
            Execute.EmbeddedScript("09_CreateQuartzTablesMigration.Down.sql");
        }
    }
}
