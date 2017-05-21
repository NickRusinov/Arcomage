using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.VersionTableInfo;

namespace Arcomage.Network.Migrations
{
    [VersionTableMetaData]
    public class VersionTableMetaData : DefaultVersionTableMetaData
    {
        public override string SchemaName => "migration";
    }
}
