using Inviter.Application.Commands.GetImages;
using Inviter.Domain.Aggregate;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Guest.Pages
{
    public partial class Images
    {
        [Inject]
        public IMediator _mediator { get; set; }

        private List<Image> images { get; set; }

        private long? selectedImage { get; set; }

        protected override async Task OnInitializedAsync()
            => images = await _mediator.Send(new GetImagesCommand());

        private void SelectImage(long id) 
            => selectedImage = id;
    }
}
