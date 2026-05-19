using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;
using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.Services.UserWords;

public sealed class AddWordsByGroupService : IAddWordsByGroupService
{
    private readonly IUserWordProgressRepository _userWordProgressRepository;
    private readonly IWordRepository _wordRepository;
    public AddWordsByGroupService(IUserWordProgressRepository userWordProgressRepository, IWordRepository wordRepository)
    {
        _userWordProgressRepository = userWordProgressRepository;
        _wordRepository = wordRepository;
    }
    public async Task ExecuteAsync(AddWordsByGroupDto dto, CancellationToken cancellationToken = default)
    {
        var words = await _wordRepository.GetByGroupIdAsync(dto.GroupId, cancellationToken);
        var userWordProgresses = words.Select(word => new UserWordProgress
        (
            dto.UserId,
             word.Id
        )).ToList();
        await _userWordProgressRepository.AddRangeAsync(userWordProgresses, cancellationToken);

    }

}