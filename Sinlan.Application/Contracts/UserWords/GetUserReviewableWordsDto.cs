namespace Sinlan.Application.Contracts.UserWords;

public record GetUserReviewableWordsDto(string UserId, int PageNumber, int PageSize);
