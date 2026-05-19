using Sinlan.Application.Contracts.UserWords;

namespace Sinlan.Application.IServices.UserWords;

public interface IAddUserWordService
{
    public Task ExecuteAsync(AddUserWordDto dto, CancellationToken cancellationToken = default);


}