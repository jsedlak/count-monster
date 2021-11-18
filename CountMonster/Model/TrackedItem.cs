namespace CountMonster.Model;

public class TrackedItem
{
    public string? Title { get; set; }

    public string? Key { get; set; }

    public int Version { get; set; } = 0;

    public int LifetimeCount => Runs.Count + ArchivedRuns.Count;

    public List<TrackedRun> Runs { get; set; } = new List<TrackedRun>();

    public List<TrackedRun> ArchivedRuns { get; set; } = new List<TrackedRun>();
}
