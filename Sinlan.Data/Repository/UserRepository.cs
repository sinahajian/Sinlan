using MongoDB.Driver;
using Sinlan.Data.Context;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Data.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{

    public UserRepository(ISinLanContext context) : base(context.Users)
    {
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await Collection.Find(user => user.Email == email).FirstOrDefaultAsync(cancellationToken);
    }
}
