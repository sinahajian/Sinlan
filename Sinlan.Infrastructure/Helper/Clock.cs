


using Sinlan.Domain.IRepository;

namespace Sinlan.Infrastructure.Helper;

public sealed class Clock : IClock
{
    public DateOnly Today()
    {
        return DateOnly.FromDateTime(DateTime.Today);
    }

    public DateOnly DayAfter(int nextDays)
    {
        return DateOnly.FromDateTime(DateTime.Today.AddDays(nextDays));
    }
}