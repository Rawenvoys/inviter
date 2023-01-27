using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components
{
    public partial class WarningTextComponent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string? Color { get; set; }
        [Parameter]
        public bool? IsItalic { get; set; }
    }
}
