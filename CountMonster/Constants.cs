using CountMonster.Model;

namespace CountMonster
{
    public class Constants
    {
        public static class Buttons
        {
            public const string Primary = "bg-brand text-white border-transparent";
            public const string Danger = "bg-red-600 text-white";
        }

        public static readonly IEnumerable<Release> Releases = new[]
        {
            new Release(1, "Updates to Existing Functionality", "ReleaseOne")
        };
    }
}
