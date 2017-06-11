using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x08, "Create quartz schema migration")]
    public class CreateQuartzSchemaMigration : Migration
    {
        public override void Up()
        {
            Create.Schema("quartz");
        }

        public override void Down()
        {
            Delete.Schema("quartz");
        }
    }
}
