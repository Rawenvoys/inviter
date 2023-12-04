using Inviter.Application.Commands.GetImages;
using Inviter.Application.Models;
using Inviter.Domain.Aggregate;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace Inviter.Web.Guest.Pages
{
    public partial class Galery
    {
        [Inject]
        public IOptions<GuestAppSettings> _appSettings { get; set; }

        public string GaleryPathUrl;

        protected override async Task OnInitializedAsync() 
            => GaleryPathUrl = _appSettings?.Value.GaleryPathUrl ?? throw new Exception();

    }
}
