using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.IServices.UserWords;

public interface IAddWordsByLevelService
{
    public Task ExecuteAsync(AddWordsByLevelDto dto, CancellationToken cancellationToken = default);

}