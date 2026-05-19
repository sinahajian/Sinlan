using Sinlan.Application.Contracts.Auth;

namespace Sinlan.Application.IServices.Auth;



public interface IRegisterUserService
{
    Task<RegisterResultDto> ExecuteAsync(RegisterUserDTO registerUserDTO, CancellationToken cancellationToken = default);
}