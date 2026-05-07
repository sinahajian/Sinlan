using Sinlan.Domain.Entities;

namespace Sinlan.Domain.IRepository;

public interface IWordGroupRepository : IBaseRepository<WordGroup>
{
    Task<WordGroup?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<WordGroup?> GetWithWordsAsync(string id, CancellationToken cancellationToken = default);
}
