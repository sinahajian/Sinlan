namespace Sinlan.Shared.DTO.WordsDtos;

public record UserWordStatsDto(
    int TodayWordsCount,
    int TotalWordsCount,
    double ProgressPercent);