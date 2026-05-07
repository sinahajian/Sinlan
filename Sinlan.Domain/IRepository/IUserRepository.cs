using Sinlan.Domain.Entities;

namespace Sinlan.Domain.IRepository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}
