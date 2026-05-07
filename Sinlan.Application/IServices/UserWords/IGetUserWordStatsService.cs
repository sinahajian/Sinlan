using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.IServices.UserWords;

public interface IGetUserWordStatsService
{
    public Task<UserWordStatsDto> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default);
}