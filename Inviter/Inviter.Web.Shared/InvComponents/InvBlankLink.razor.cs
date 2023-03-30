using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Shared.InvComponents
{
    public partial class InvBlankLink
    {
        [Parameter]
        public string Link { get; set; }

        [Parameter]
        public string Text { get; set; }
    }
}
