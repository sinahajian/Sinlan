using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.Enums;
using Sinlan.Domain.IRepository;

namespace Sinlan.Data.Repository;

public class WordRepository : BaseRepository<Word>, IWordRepository
{

    public WordRepository(ISinLanContext context) : base(context.Words)
    {
    }

    public async Task<Word?> GetByTextAsync(string text, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(word => word.Text == text).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Word>> GetByGroupIdAsync(string groupId, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(word => word.GroupId == groupId).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Word>> GetByLevelAsync(WordLevel level, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(word => word.Level == level).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Word>> GetByLanguageAsync(WordLang wordLang, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(word => word.WordLang == wordLang).ToListAsync(cancellationToken);
    }
}
