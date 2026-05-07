namespace Sinlan.Domain.Entities
{
    public class UserWordProgress : BaseEntity
    {
        public string UserId { get; set; }
        //public User User { get; set; }
        public string WordId { get; set; }
        // public Word Word { get; set; }
        public int RepetitionCount { get; set; } = 0;
        public long LastReviewedAt { get; set; }
        public long NextReviewAt { get; set; }
        public double EaseFactor { get; set; } = 2.5;
        public int IntervalDays { get; set; }
        public int CorrectStreak { get; set; } = 0;
    }
}