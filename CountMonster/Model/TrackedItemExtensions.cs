using CountMonster.Extensions;

namespace CountMonster.Model;

public static class TrackedItemExtensions
{
    public static TimeSpan TotalTime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(item.Runs.Sum(m => m.Duration));
    }

    public static TimeSpan TotalTimeLifetime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(
            item.Runs.Sum(m => m.Duration) +
            item.ArchivedRuns.Sum(m =>m.Duration)
        );
    }

    public static TimeSpan AvgRunTime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(item.Runs.Average(m => m.Duration));
    }

    public static TimeSpan AvgLifetimeRunTime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(item.Runs.Union(item.ArchivedRuns).Average(m => m.Duration));
    }

    public static TimeSpan MedianRunTime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(item.Runs.Median(m => m.Duration));
    }

    public static TimeSpan MedianLifetimeRunTime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(item.Runs.Union(item.ArchivedRuns).Median(m => m.Duration));
    }

    public static double HitRate(this TrackedItem item)
    {
        return item.Runs.Average(m => { return string.IsNullOrWhiteSpace(m.Comments) ? 0 : 1; }) * 100;
    }

    public static double HitRateLifetime(this TrackedItem item)
    {
        return item.Runs.Union(item.ArchivedRuns).Average(m => { return string.IsNullOrWhiteSpace(m.Comments) ? 0 : 1; }) * 100;
    }
}
