using Sinlan.Domain.Entities;

namespace Sinlan.Domain.IRepository;

public interface IUserWordProgressRepository : IBaseRepository<UserWordProgress>
{
    Task<UserWordProgress?> GetByUserAndWordAsync(string userId, string wordId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserWordProgress>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<long> GetByUserIdCountAsync(string userId, CancellationToken cancellationToken = default);
    Task<long> GetByUserIdReviewableWordsCountAsync(string userId, DateOnly today, CancellationToken cancellationToken = default);
    Task<long> GetByUserIdLearnedCountAsync(string userId, CancellationToken cancellationToken = default);
    Task<long> GetByUserIdInprogressCountAsync(string userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserWordProgress>> GetByUserIdReviewableWordsByPageAsync(string userId, DateOnly today, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserWordProgress>> GetByUserIdByPageAsync(string userId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<UserWordProgress> userWordProgresses, CancellationToken cancellationToken = default);
}