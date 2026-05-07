using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Data.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly SinLanContext Context;
    protected readonly IMongoCollection<TEntity> Collection;

    public BaseRepository(SinLanContext context)
    {
        Context = context;
        Collection = ResolveCollection(context);
    }

    public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(entity => entity.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(current => current.Id == entity.Id, entity, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        await Collection.DeleteOneAsync(entity => entity.Id == id, cancellationToken);
    }

    private static IMongoCollection<TEntity> ResolveCollection(SinLanContext context)
    {
        var collectionProperty = context.GetType().GetProperty(typeof(TEntity).Name + "s");
        var collection = collectionProperty?.GetValue(context) as IMongoCollection<TEntity>;

        return collection
            ?? throw new InvalidOperationException($" collection for entity '{typeof(TEntity).Name}' was not found.");
    }
}
