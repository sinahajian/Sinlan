using Sinlan.Shared.DTO.WordsDtos;
namespace Sinlan.Application.IServices.UserWords;

public interface IAddWordsByLevelService
{
    public Task ExecuteAsync(AddWordsByLevelDto dto, CancellationToken cancellationToken = default);

}