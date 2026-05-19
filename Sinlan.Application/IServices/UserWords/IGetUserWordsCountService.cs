using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.IServices.UserWords;

public interface IGetUserWordsCountService
{
    public Task<long> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default);
}