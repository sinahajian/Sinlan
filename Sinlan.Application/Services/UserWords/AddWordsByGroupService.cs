using Sinlan.Application.IServices.UserWords;
using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.Services.UserWords;

public sealed class AddWordsByGroupService : IAddWordsByGroupService
{
    public Task ExecuteAsync(AddWordsByGroupDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}