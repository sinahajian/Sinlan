using Sinlan.Application.IServices.UserWords;
using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.Services.UserWords;

public sealed class AddWordsByLevelService : IAddWordsByLevelService
{
    public Task ExecuteAsync(AddWordsByLevelDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}