using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.IServices.UserWords;

public interface IGetUserWordStatsService
{
    public Task<UserWordStatsDto> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default);
}