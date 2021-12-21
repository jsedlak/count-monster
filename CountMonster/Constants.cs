using CountMonster.Model;

namespace CountMonster
{
    public class Constants
    {
        /// <summary>
        /// The current version of the app
        /// </summary>
        public const int AppVersion = 2;

        public static class Buttons
        {
            public const string Primary = "bg-brand text-white border-transparent";
            public const string Danger = "bg-red-600 text-white";
        }

        public static readonly IEnumerable<Release> Releases = new[]
        {
            new Release(1, "Updates to Existing Functionality", "ReleaseOne"),
            new Release(2, "Making it easier to get stuff done", "ReleaseTwo")
        };
    }
}
