using Microsoft.AspNetCore.Components;

namespace CountMonster.Model
{
    public class NavItem
    {
        public string Title { get; set; }

        public RenderFragment Icon { get; set; }
    }
}
