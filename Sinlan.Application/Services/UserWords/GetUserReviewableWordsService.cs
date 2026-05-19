using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.IRepository;
using Sinlan.Application.Contracts.UserWords;
using System.Linq;
using Sinlan.Application.IServices;
namespace Sinlan.Application.Services.UserWords;

public sealed class GetUserReviewableWordsService : IGetUserReviewableWordsService
{
    private readonly IUserWordProgressRepository _userWordProgressRepository;
    private readonly IWordRepository _wordRepository;
    private readonly IClock _clock;
    public GetUserReviewableWordsService(IUserWordProgressRepository userWordProgressRepository, IWordRepository wordRepository, IClock clock)
    {
        _userWordProgressRepository = userWordProgressRepository;
        _wordRepository = wordRepository;
        _clock = clock;
    }

    public async Task<GetUserReviewableWordsResultDto> ExecuteAsync(GetUserReviewableWordsDto dto, CancellationToken cancellationToken = default)
    {
        var userWordProgresses = await _userWordProgressRepository.GetByUserIdReviewableWordsByPageAsync(dto.UserId, _clock.Today(), dto.PageNumber, dto.PageSize, cancellationToken);

        var reviewableWords = await _wordRepository.GetByIdsAsync(userWordProgresses.Select(uwp => uwp.WordId).ToList(), cancellationToken); //  the sort is not important


        return new GetUserReviewableWordsResultDto
        (
            dto.UserId,
            reviewableWords.Select(word => new WordsDto
            (word.Text, word.Explanation))
        );
    }

}