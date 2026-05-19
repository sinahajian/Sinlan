using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Data.Repository;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    // protected readonly ISinLanContext _context;

    protected readonly IMongoCollection<TEntity> Collection;

    public BaseRepository(IMongoCollection<TEntity> collection)
    {
        Collection = collection;

    }

    public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(entity => entity.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
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



    public async Task<IReadOnlyList<TEntity>> GetByIdsAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(entity => ids.Contains(entity.Id)).ToListAsync(cancellationToken);
    }
}
