namespace Sinlan.Shared.DTO.WordsDtos;

public record UserTodayWordsResultDto(string UserId, IEnumerable<WordsDto> Words);