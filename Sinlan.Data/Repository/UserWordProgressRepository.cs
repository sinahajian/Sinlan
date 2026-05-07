using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Data.Repository;

public class UserWordProgressRepository : BaseRepository<UserWordProgress>, IUserWordProgressRepository
{
    public UserWordProgressRepository(SinLanContext context) : base(context)
    {
    }

    public async Task<UserWordProgress?> GetByUserAndWordAsync(string userId, string wordId, CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(progress => progress.UserId == userId && progress.WordId == wordId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<UserWordProgress>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(progress => progress.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<UserWordProgress>> GetByUserIdByPageAsync(string userId, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(progress => progress.UserId == userId)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync(cancellationToken);
    }
}
