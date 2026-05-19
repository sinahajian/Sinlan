using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.IRepository;
using Sinlan.Application.Contracts.UserWords;
using Sinlan.Application.IServices;
namespace Sinlan.Application.Services.UserWords;

public sealed class GetUserWordStatsService : IGetUserWordStatsService
{
    private readonly IUserWordProgressRepository _userWordProgressRepository;
    private readonly IClock _clock;
    public GetUserWordStatsService(IUserWordProgressRepository userWordProgressRepository, IClock clock)
    {
        _userWordProgressRepository = userWordProgressRepository;
        _clock = clock;
    }
    public async Task<UserWordStatsDto> ExecuteAsync(GetUserWordsCountDto dto, CancellationToken cancellationToken = default)
    {
        var reviewableCount = await _userWordProgressRepository.GetByUserIdReviewableWordsCountAsync(dto.UserId, _clock.Today(), cancellationToken);
        var inprogressCount = await _userWordProgressRepository.GetByUserIdInprogressCountAsync(dto.UserId, cancellationToken);
        var learnedCount = await _userWordProgressRepository.GetByUserIdLearnedCountAsync(dto.UserId, cancellationToken);
        var totalCount = await _userWordProgressRepository.GetByUserIdCountAsync(dto.UserId, cancellationToken);

        return new UserWordStatsDto(
             ReviewableWordsCount: reviewableCount,
             TotalLearnedWordsCount: learnedCount,
             TotalInprogressWordsCount: inprogressCount,
             ProgressPercent: totalCount == 0 ? 0 : (double)learnedCount / totalCount * 100
         );
    }

}