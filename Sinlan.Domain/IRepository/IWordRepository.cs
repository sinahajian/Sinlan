using Sinlan.Domain.Entities;
using Sinlan.Domain.Enums;

namespace Sinlan.Domain.IRepository;

public interface IWordRepository : IBaseRepository<Word>
{
    Task<Word?> GetByTextAsync(string text, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Word>> GetByGroupIdAsync(string groupId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Word>> GetByLevelAsync(WordLevel level, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Word>> GetByLanguageAsync(WordLang wordLang, CancellationToken cancellationToken = default);
}
