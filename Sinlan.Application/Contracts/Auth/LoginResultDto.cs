namespace Sinlan.Application.Contracts.Auth;

public record LoginResultDto(bool Success, string Message, string UserId);