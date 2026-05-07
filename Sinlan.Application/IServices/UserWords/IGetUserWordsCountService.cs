using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.IServices.UserWords;

public interface IGetUserWordsCountService
{
    public Task<int> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default);
}