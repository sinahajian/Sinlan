using Sinlan.Shared.DTO.UserDTO;
namespace Sinlan.Application.IServices.Auth;

public interface ILoginUserService
{
    Task<LoginResultDto> ExecuteAsync(LoginUserDTO loginUserDTO, CancellationToken cancellationToken = default);
}