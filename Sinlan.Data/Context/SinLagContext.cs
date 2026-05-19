using MongoDB.Driver;
using Sinlan.Domain.Entities;

namespace Sinlan.Data.Context;

public class SinLanContext : ISinLanContext
{
    public readonly IMongoDatabase Database;

    public IMongoCollection<User> Users => Database.GetCollection<User>("Users");
    public IMongoCollection<UserWordProgress> UserWordProgresses => Database.GetCollection<UserWordProgress>("UserWordProgresses");
    public IMongoCollection<Word> Words => Database.GetCollection<Word>("Words");
    public IMongoCollection<WordGroup> WordGroups => Database.GetCollection<WordGroup>("WordGroups");

    public SinLanContext(IMongoClient client)
    {
        Database = client.GetDatabase("SinlanDb");
        createIndexes();
    }

    static SinLanContext()
    {
        MongoMappings.Register();


    }
    private void createIndexes()
    {
        var userWordProgressIndexKeys = Builders<UserWordProgress>.IndexKeys
            .Ascending(progress => progress.UserId)
            .Ascending(progress => progress.WordId);
        var userWordProgressIndexModel = new CreateIndexModel<UserWordProgress>(userWordProgressIndexKeys, new CreateIndexOptions { Unique = true });
        UserWordProgresses.Indexes.CreateOne(userWordProgressIndexModel);
    }

}
