namespace CountMonster.Model;

public class TrackedRun
{
    public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.UtcNow;

    public int Number { get; set; }

    public string? Comments { get; set; }

    public float Duration { get; set; }
}
