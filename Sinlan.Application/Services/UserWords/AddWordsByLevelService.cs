using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.Entities;
using Sinlan.Domain.Enums;
using Sinlan.Domain.IRepository;
using Sinlan.Application.Contracts.UserWords;
namespace Sinlan.Application.Services.UserWords;

public sealed class AddWordsByLevelService : IAddWordsByLevelService
{
    private readonly IUserWordProgressRepository _userWordProgressRepository;
    private readonly IWordRepository _wordRepository;
    public AddWordsByLevelService(IUserWordProgressRepository userWordProgressRepository, IWordRepository wordRepository)
    {
        _userWordProgressRepository = userWordProgressRepository;
        _wordRepository = wordRepository;
    }
    public async Task ExecuteAsync(AddWordsByLevelDto dto, CancellationToken cancellationToken = default)
    {
        var words = await _wordRepository.GetByLevelAsync((WordLevel)dto.Level, cancellationToken);
        var userWordProgresses = words.Select(word => new UserWordProgress
        (
            dto.UserId,
             word.Id
        )).ToList();
        await _userWordProgressRepository.AddRangeAsync(userWordProgresses, cancellationToken);
    }

}