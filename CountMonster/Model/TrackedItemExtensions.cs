using CountMonster.Extensions;

namespace CountMonster.Model;

public static class TrackedItemExtensions
{
    public static IEnumerable<TrackedRun> GetLifetimeRuns(this TrackedItem item)
    {
        if(!item.Runs.Any())
        {
            return item.ArchivedRuns;
        }

        if(!item.ArchivedRuns.Any())
        {
            return item.Runs;
        }

        return item.Runs.Union(item.ArchivedRuns);
    }

    public static TimeSpan TotalTime(this TrackedItem item)
    {
        if(!item.Runs.Any())
        {
            return TimeSpan.Zero;
        }

        return TimeSpan.FromSeconds(item.Runs.Sum(m => m.Duration));
    }

    public static TimeSpan TotalTimeLifetime(this TrackedItem item)
    {
        return TimeSpan.FromSeconds(item.GetLifetimeRuns().Sum(m => m.Duration));
    }

    public static TimeSpan AvgRunTime(this TrackedItem item)
    {
        if(!item.Runs.Any())
        {
            return TimeSpan.Zero;
        }

        return TimeSpan.FromSeconds(item.Runs.Average(m => m.Duration));
    }

    public static TimeSpan AvgLifetimeRunTime(this TrackedItem item)
    {
        var allRuns = item.GetLifetimeRuns();

        if(!allRuns.Any())
        {
            return TimeSpan.Zero;
        }

        return TimeSpan.FromSeconds(allRuns.Average(m => m.Duration));
    }

    public static TimeSpan MedianRunTime(this TrackedItem item)
    {
        if (!item.Runs.Any())
        {
            return TimeSpan.Zero;
        }

        return TimeSpan.FromSeconds(item.Runs.Median(m => m.Duration));
    }

    public static TimeSpan MedianLifetimeRunTime(this TrackedItem item)
    {
        var allRuns = item.GetLifetimeRuns();

        if (!allRuns.Any())
        {
            return TimeSpan.Zero;
        }

        return TimeSpan.FromSeconds(allRuns.Median(m => m.Duration));
    }

    public static double HitRate(this TrackedItem item)
    {
        if (!item.Runs.Any())
        {
            return 0;
        }

        return item.Runs.Average(m => { return string.IsNullOrWhiteSpace(m.Comments) ? 0 : 1; }) * 100;
    }

    public static double HitRateLifetime(this TrackedItem item)
    {
        var allRuns = item.GetLifetimeRuns();

        if (!allRuns.Any())
        {
            return 0;
        }

        return allRuns.Average(m => { return string.IsNullOrWhiteSpace(m.Comments) ? 0 : 1; }) * 100;
    }
}
