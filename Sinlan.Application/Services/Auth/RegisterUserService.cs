using Sinlan.Application.IServices.Auth;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;
using Sinlan.Shared.DTO.UserDTO;
namespace Sinlan.Application.Services.Auth;

public sealed class RegisterUserService : IRegisterUserService
{
    private readonly IUserRepository _userService;
    private readonly IPasswordHasher _passwordHasher;
    public RegisterUserService(IUserRepository userService, IPasswordHasher passwordHasher)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
    }


    public async Task<RegisterResultDto> ExecuteAsync(RegisterUserDTO registerUserDTO, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(registerUserDTO.Email) || string.IsNullOrEmpty(registerUserDTO.Password))
        {
            return await Task.FromResult(new RegisterResultDto
            (
                Success: false,
                Message: "Email and password are required.",
                UserId: string.Empty
            ));
        }
        else
        {
            var existingUser = await _userService.GetByEmailAsync(registerUserDTO.Email, cancellationToken);
            if (existingUser != null)
            {
                return await Task.FromResult(new RegisterResultDto
                (
                    Success: false,
                    Message: "Email is already registered.",
                    UserId: string.Empty
                ));
            }
            else
            {
                var newUser = new User
                {
                    Name = registerUserDTO.Username,
                    Email = registerUserDTO.Email,
                };
                newUser.SetPassword(_passwordHasher.Hash(registerUserDTO.Password));
                var createdUser = await _userService.AddAsync(newUser, cancellationToken);
                return await Task.FromResult(new RegisterResultDto
                (
                    Success: true,
                    Message: "Registration successful.",
                    UserId: createdUser.Id.ToString()
                ));
            }
        }

    }
}