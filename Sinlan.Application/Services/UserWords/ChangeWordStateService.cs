using Sinlan.Application.IServices;
using Sinlan.Application.IServices.UserWords;
using Sinlan.Domain.Entities;
using Sinlan.Domain.IRepository;

namespace Sinlan.Application.Services.UserWords
{
    public sealed class ChangeWordStateService : IChangeWordStateService
    {
        IUserWordProgressRepository _userWordProgressRepository;
        IClock _clock;
        public ChangeWordStateService(IUserWordProgressRepository userWordProgressRepository, IClock clock)
        {
            _userWordProgressRepository = userWordProgressRepository;
            _clock = clock;
        }
        public async Task ReadWordAsync(string userId, string wordId, byte quality, CancellationToken cancellationToken = default)
        {

            var word = await _userWordProgressRepository.GetByUserAndWordAsync(userId, wordId, cancellationToken);
            if (word != null)
            {
                word.SetWordState(quality, _clock.Today());
                await _userWordProgressRepository.UpdateAsync(word, cancellationToken);
            }




        }
        public Task ReadWordsAsync(string userId, IEnumerable<(string wordId, byte quality)> wordsStates, CancellationToken cancellationToken = default)
        {




            var tasks = wordsStates.Select(async ws =>
            {
                var word = await _userWordProgressRepository.GetByUserAndWordAsync(userId, ws.wordId, cancellationToken);
                if (word != null)
                {
                    word.SetWordState(ws.quality, _clock.Today());
                    await _userWordProgressRepository.UpdateAsync(word, cancellationToken);
                }
            });
            return Task.WhenAll(tasks);

        }


    }
}