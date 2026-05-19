using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.IRepository;
using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.Services.UserWords;

public sealed class GetUserWordsCountService : IGetUserWordsCountService
{
    private readonly IUserWordProgressRepository _userWordProgressRepository;
    public GetUserWordsCountService(IUserWordProgressRepository userWordProgressRepository)
    {
        _userWordProgressRepository = userWordProgressRepository;
    }
    public async Task<long> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default)
    {
        return await _userWordProgressRepository.GetByUserIdCountAsync(dto.UserId, cancellationToken);

    }


}