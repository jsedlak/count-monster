namespace CountMonster.Model;

public class AppMetaData
{
    public int Version { get; set; } = 1;

    public bool HideAddCounterCard { get; set; } = false;

    public int LatestVersionRead { get; set; } = 0;
}

