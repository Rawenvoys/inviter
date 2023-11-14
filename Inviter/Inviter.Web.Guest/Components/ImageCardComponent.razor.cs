using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components
{
    public partial class ImageCardComponent
    {
        [Parameter]
        public string ImagePath { get; set; }
    }
}
