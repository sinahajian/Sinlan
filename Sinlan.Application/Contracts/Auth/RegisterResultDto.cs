namespace Sinlan.Application.Contracts.Auth;

public record RegisterResultDto(bool Success, string Message, string UserId);