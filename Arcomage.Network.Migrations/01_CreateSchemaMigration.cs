using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x01, "Create schema migration")]
    public class CreateSchemaMigration : Migration
    {
        public override void Up()
        {
            if (Schema.Schema("public").Exists())
                return;

            Create.Schema("public");
        }

        public override void Down()
        {
            Delete.Schema("public");
        }
    }
}
