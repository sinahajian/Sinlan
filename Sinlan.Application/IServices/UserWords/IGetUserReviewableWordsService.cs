using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.IServices.UserWords;

public interface IGetUserReviewableWordsService
{
    public Task<GetUserReviewableWordsResultDto> ExecuteAsync(GetUserReviewableWordsDto dto, CancellationToken cancellationToken = default);

}