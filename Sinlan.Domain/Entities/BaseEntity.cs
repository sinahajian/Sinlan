namespace Sinlan.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public long CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    }
}