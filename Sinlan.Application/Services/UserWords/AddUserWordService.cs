using Sinlan.Application.IServices.UserWords;
using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.Services.UserWords;

public sealed class AddUserWordService : IAddUserWordService
{
    public Task ExecuteAsync(AddUserWordDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}