using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.IServices.UserWords;

public interface IGetUserTodayWordsService
{
    public Task<UserTodayWordsResultDto> ExecuteAsync(GetUserTodayWordsDto dto, CancellationToken cancellationToken = default);

}