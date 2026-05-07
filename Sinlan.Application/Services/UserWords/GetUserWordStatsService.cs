using Sinlan.Application.IServices.UserWords;
using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.Services.UserWords;

public sealed class GetUserWordStatsService : IGetUserWordStatsService
{
    public Task<UserWordStatsDto> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}