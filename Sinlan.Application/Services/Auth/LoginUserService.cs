using Sinlan.Application.IServices.Auth;
using Sinlan.Domain.IRepository;
using Sinlan.Application.Contracts.Auth;

namespace Sinlan.Application.Services.Auth;

public sealed class LoginUserService : ILoginUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginUserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<LoginResultDto> ExecuteAsync(LoginUserDTO loginUserDTO, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(loginUserDTO.Email) || string.IsNullOrEmpty(loginUserDTO.Password))
        {
            return await Task.FromResult(new LoginResultDto
            (
                Success: false,
                Message: "Email and password are required.",
                UserId: string.Empty
            ));
        }
        else
        {
            var user = await _userRepository.GetByEmailAsync(loginUserDTO.Email, cancellationToken);
            if (user == null || !_passwordHasher.Verify(hashedPassword: user.PasswordHashed, providedPassword: loginUserDTO.Password))
            {
                return await Task.FromResult(new LoginResultDto
                (
                    Success: false,
                    Message: "Invalid email or password.",
                    UserId: string.Empty
                ));
            }
            else
            {
                return await Task.FromResult(new LoginResultDto
                (
                    Success: true,
                    Message: "Login successful.",
                    UserId: user.Id.ToString()
                ));
            }
        }
    }
}