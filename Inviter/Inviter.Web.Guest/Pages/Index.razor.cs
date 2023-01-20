using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    [Route("/Zaproszenie/{code:guid}")]
    public partial class Index
    {
        [Parameter]
        public Guid Code { get; set; }

        //protected override void OnInitialized()
        //{
        //    Text ??= "fantastic";
        //}
    }
}
