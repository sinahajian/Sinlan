namespace Sinlan.Application.Contracts.UserWords;

public record GetUserReviewableWordsResultDto(string UserId, IEnumerable<WordsDto> Words);