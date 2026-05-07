using Sinlan.Application.IServices.UserWords;
using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.Services.UserWords;

public sealed class GetUserTodayWordsService : IGetUserTodayWordsService
{
    public Task<UserTodayWordsResultDto> ExecuteAsync(GetUserTodayWordsDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}