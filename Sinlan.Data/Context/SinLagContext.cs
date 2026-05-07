using MongoDB.Driver;
using Sinlan.Domain.Entities;

namespace Sinlan.Data.Context;

public class SinLanContext
{
    private readonly IMongoDatabase _database;

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    public IMongoCollection<UserWordProgress> UserWordProgresses => _database.GetCollection<UserWordProgress>("UserWordProgresses");
    public IMongoCollection<Word> Words => _database.GetCollection<Word>("Words");
    public IMongoCollection<WordGroup> WordGroups => _database.GetCollection<WordGroup>("WordGroups");

    public SinLanContext(IMongoClient client)
    {
        _database = client.GetDatabase("SinlanDb");
    }

    static SinLanContext()
    {
        MongoMappings.Register();
    }
}
