using Sinlan.Application.Contracts.UserWords;
using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Application.Services.UserWords;

public sealed class AddUserWordService : IAddUserWordService
{
    private readonly IUserWordProgressRepository _userWordProgressRepository;
    public AddUserWordService(IUserWordProgressRepository userWordProgressRepository)
    {
        _userWordProgressRepository = userWordProgressRepository;
    }
    public async Task ExecuteAsync(AddUserWordDto dto, CancellationToken cancellationToken = default)
    {
        await _userWordProgressRepository.AddAsync(new UserWordProgress(dto.UserId,
            dto.WordId), cancellationToken);
    }

}