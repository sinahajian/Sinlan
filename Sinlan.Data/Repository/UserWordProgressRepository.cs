using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;


namespace Sinlan.Data.Repository;

public class UserWordProgressRepository : BaseRepository<UserWordProgress>, IUserWordProgressRepository
{

    public UserWordProgressRepository(ISinLanContext context) : base(context.UserWordProgresses)
    {

    }




    public async Task AddRangeAsync(IEnumerable<UserWordProgress> userWordProgresses, CancellationToken cancellationToken = default)
    {
        try
        {
            await Collection.InsertManyAsync(userWordProgresses, new InsertManyOptions { IsOrdered = false }, cancellationToken);
        }
        catch (MongoBulkWriteException ex) when (ex.WriteErrors.All(error => error.Category == ServerErrorCategory.DuplicateKey))
        {
            await Task.CompletedTask;
        }

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
            .SortByDescending(progress => progress.NextReviewAt)
            .ThenBy(progress => progress.WordId)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync(cancellationToken);
    }

    public Task<long> GetByUserIdCountAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Collection
            .Find(progress => progress.UserId == userId)
            .CountDocumentsAsync(cancellationToken);
    }

    public Task<long> GetByUserIdInprogressCountAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Collection
            .Find(progress => progress.UserId == userId && progress.IsLearned == false && progress.RepetitionCount > 0)
            .CountDocumentsAsync(cancellationToken);
    }

    public Task<long> GetByUserIdLearnedCountAsync(string userId, CancellationToken cancellationToken = default)
    {
        return Collection
            .Find(progress => progress.UserId == userId && progress.IsLearned == true)
            .CountDocumentsAsync(cancellationToken);
    }

    public Task<long> GetByUserIdReviewableWordsCountAsync(string userId, DateOnly today, CancellationToken cancellationToken = default)
    {
        return Collection
            .Find(
               progress => progress.UserId == userId &&
               (progress.NextReviewAt == null
            ||
              progress.NextReviewAt <= today))



            .CountDocumentsAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<UserWordProgress>> GetByUserIdReviewableWordsByPageAsync(string userId, DateOnly today, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(
               progress => progress.UserId == userId &&
               (progress.NextReviewAt == null
            ||
              progress.NextReviewAt <= today))
               .SortByDescending(progress => progress.NextReviewAt)
            .ThenBy(progress => progress.WordId)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync(cancellationToken);
    }
    public override async Task<UserWordProgress> AddAsync(UserWordProgress entity, CancellationToken cancellationToken = default)
    {
        try
        {
            return await base.AddAsync(entity, cancellationToken);

        }
        catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            return entity;
        }
    }
}
