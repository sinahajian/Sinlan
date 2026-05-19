using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Data.Repository;

public class WordGroupRepository : BaseRepository<WordGroup>, IWordGroupRepository
{

    public WordGroupRepository(ISinLanContext context) : base(context.WordGroups)
    {
    }

    public async Task<WordGroup?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(group => group.Name == name).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<WordGroup?> GetWithWordsAsync(string id, CancellationToken cancellationToken = default)
    {
        return await GetByIdAsync(id, cancellationToken);
    }
}
