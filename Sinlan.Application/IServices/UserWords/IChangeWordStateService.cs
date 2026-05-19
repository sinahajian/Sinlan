namespace Sinlan.Application.IServices.UserWords
{
    public interface IChangeWordStateService
    {
        Task ReadWordAsync(string userId, string wordId, byte quality, CancellationToken cancellationToken = default);
        Task ReadWordsAsync(string userId, IEnumerable<(string wordId, byte quality)> wordsStates, CancellationToken cancellationToken = default);
    }
}