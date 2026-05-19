namespace Sinlan.Application.Contracts.UserWords;

public record UserWordStatsDto(
    long ReviewableWordsCount,
    long TotalLearnedWordsCount,
    long TotalInprogressWordsCount,
    double ProgressPercent);