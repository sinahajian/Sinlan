namespace Sinlan.Application.IServices.Auth;

using Sinlan.Shared.DTO.UserDTO;

public interface IRegisterUserService
{
    Task<RegisterResultDto> ExecuteAsync(RegisterUserDTO registerUserDTO, CancellationToken cancellationToken = default);
}