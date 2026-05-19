namespace Sinlan.Application.IServices;

public interface IClock
{
    DateOnly Today();
    DateOnly DayAfter(int nextDays);
}