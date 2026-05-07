using Sinlan.Application.IServices.UserWords;
using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.Services.UserWords;

public sealed class GetUserWordsCountService : IGetUserWordsCountService
{
    public Task<int> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}