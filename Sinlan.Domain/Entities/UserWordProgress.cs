


namespace Sinlan.Domain.Entities
{
    public class UserWordProgress : BaseEntity
    {
        public string UserId { get; set; }
        //public User User { get; set; }
        public string WordId { get; set; }
        // public Word Word { get; set; }
        public int RepetitionCount { get; set; } = 0;
        public DateOnly? LastReviewedAt { get; set; }
        public DateOnly? NextReviewAt { get; set; }
        public double EaseFactor { get; set; } = 2.5;
        public int IntervalDays { get; set; }
        public int CorrectStreak { get; set; } = 0;
        public bool IsLearned { get; set; } = false;
        public UserWordProgress(string userId, string wordId)
        {
            UserId = userId;
            WordId = wordId;

        }
        public UserWordProgress()
        {

        }
        public UserWordProgress SetWordState(byte quality, DateOnly today)
        {
            if (quality > 5)

                throw new ArgumentOutOfRangeException(

                    nameof(quality),

                    "Quality must be between 0 and 5.");

            if (quality < 3)

            {

                RepetitionCount = 0;

                IntervalDays = 1;

                CorrectStreak = 0;

            }

            else

            {

                CorrectStreak++;

                if (RepetitionCount == 0)

                    IntervalDays = 1;

                else if (RepetitionCount == 1)

                    IntervalDays = 6;

                else

                    IntervalDays =

                        (int)Math.Round(

                            IntervalDays * EaseFactor);

                RepetitionCount++;

            }

            EaseFactor +=

                (0.1 - (5 - quality) *

                (0.08 + (5 - quality) * 0.02));

            if (EaseFactor < 1.3)

                EaseFactor = 1.3;

            LastReviewedAt =

                today;

            NextReviewAt =
                today.AddDays(IntervalDays);
            IsLearned =

                RepetitionCount >= 5;

            return this;

        }
    }
}