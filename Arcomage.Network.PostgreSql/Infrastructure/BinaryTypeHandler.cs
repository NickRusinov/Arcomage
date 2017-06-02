using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Arcomage.Network.PostgreSql.Infrastructure
{
    public class BinaryTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override T Parse(object value)
        {
            if (value is byte[] byteArryaValue)
            {
                using (var stream = new MemoryStream(byteArryaValue))
                {
                    var formatter = new BinaryFormatter();
                    return (T)formatter.Deserialize(stream);
                }
            }

            throw new NotSupportedException();
        }

        public override void SetValue(IDbDataParameter parameter, T value)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);

                stream.Position = 0;
                parameter.Value = stream.ToArray();
            }
        }
    }
}
