using MongoDB.Driver;
using Sinlan.Domain.Entities;

namespace Sinlan.Data.Context;

public interface ISinLanContext
{


    public IMongoCollection<User> Users { get; }
    public IMongoCollection<UserWordProgress> UserWordProgresses { get; }
    public IMongoCollection<Word> Words { get; }
    public IMongoCollection<WordGroup> WordGroups { get; }



}
