using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Sinlan.Domain.Entities;

namespace Sinlan.Data.Context;

public static class MongoMappings
{
    public static void Register()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(BaseEntity)))
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
                cm.MapIdMember(x => x.Id)
                  .SetSerializer(new StringSerializer(BsonType.ObjectId))
                  .SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}
