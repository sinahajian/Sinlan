using Sinlan.Application.Contracts.UserWords;

namespace Sinlan.Application.IServices.UserWords;

public interface IAddWordsByGroupService
{
    public Task ExecuteAsync(AddWordsByGroupDto dto, CancellationToken cancellationToken = default);

}