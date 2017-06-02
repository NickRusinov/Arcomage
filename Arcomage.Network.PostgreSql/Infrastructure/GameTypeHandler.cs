using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Dapper;

namespace Arcomage.Network.PostgreSql.Infrastructure
{
    public class GameTypeHandler : SqlMapper.TypeHandler<Game>
    {
        private readonly ConcurrentDictionary<Guid, Game> gameStorage = new ConcurrentDictionary<Guid, Game>();

        public override Game Parse(object value)
        {
            if (value is byte[] valueByteArray)
            {
                var id = GetIdFromByteArray(valueByteArray);

                return gameStorage.GetOrAdd(id, _ =>
                {
                    using (var stream = new MemoryStream(valueByteArray, 16, valueByteArray.Length - 16))
                    {
                        var formatter = new BinaryFormatter();
                        return (Game)formatter.Deserialize(stream);
                    }
                });
            }

            throw new NotSupportedException();
        }

        public override void SetValue(IDbDataParameter parameter, Game value)
        {
            using (var stream = new MemoryStream())
            {
                var id = GetIdFromGameInstance(value);
                stream.Write(id.ToByteArray(), 0, 16);

                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);

                stream.Position = 0;
                parameter.Value = stream.ToArray();
            }
        }

        private Guid GetIdFromByteArray(byte[] byteArray)
        {
            var idByteArray = new byte[16];
            Array.Copy(byteArray, idByteArray, 16);

            return new Guid(idByteArray);
        }

        private Guid GetIdFromGameInstance(Game game)
        {
            lock (gameStorage)
            {
                var id = gameStorage.Where(p => p.Value == game).Select(p => p.Key).FirstOrDefault();
                if (id != Guid.Empty)
                    return id;

                return Guid.NewGuid();
            }
        }
    }
}
