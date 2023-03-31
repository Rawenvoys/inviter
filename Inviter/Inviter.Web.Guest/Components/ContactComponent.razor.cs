using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Components
{
    public partial class ContactComponent
    {
        [Parameter]
        public string FullName { get; set; }

        [Parameter]
        public string PhoneNo { get; set; }
    }
}
