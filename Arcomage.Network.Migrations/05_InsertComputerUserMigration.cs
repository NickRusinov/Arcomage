using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Arcomage.Network.Migrations
{
    [Migration(0x05, "Insert computer user migration")]
    public class InsertComputerUserMigration : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("user").InSchema("public")
                .Row(new { id = new Guid(0xe9a872c8, 0x560b, 0x48f6, 0xb3, 0xfb, 0xe8, 0x25, 0x08, 0x99, 0xbc, 0x8b), name = "Computer", state = 0 });
        }

        public override void Down()
        {
            Delete.FromTable("user").InSchema("public")
                .Row(new { id = new Guid(0xe9a872c8, 0x560b, 0x48f6, 0xb3, 0xfb, 0xe8, 0x25, 0x08, 0x99, 0xbc, 0x8b) });
        }
    }
}
