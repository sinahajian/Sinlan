using Sinlan.Domain.Entities;

namespace Sinlan.Domain.IRepository;

public interface IUserWordProgressRepository : IBaseRepository<UserWordProgress>
{
    Task<UserWordProgress?> GetByUserAndWordAsync(string userId, string wordId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserWordProgress>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<UserWordProgress>> GetByUserIdByPageAsync(string userId, int page, int pageSize, CancellationToken cancellationToken = default);
}