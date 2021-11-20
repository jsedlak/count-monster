namespace CountMonster.Model;

public class Release
{
    public Release(int version, string title, string notesComponent)
    {
        Version = version;
        Title = title; 
        NotesComponent = notesComponent;
    }

    public int Version { get; set; } = 1;

    public string Title { get; set; } = string.Empty;

    public string NotesComponent { get; set; } = string.Empty;
}
