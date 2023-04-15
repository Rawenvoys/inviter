using Inviter.Application.Commands.GenerateQRCode;
using Inviter.Application.Commands.GetQRCodeBase64;
using Microsoft.AspNetCore.Components;

namespace Inviter.Web.Admin.Pages
{
    public partial class UrlGenerator
    {
        [Inject]
        public IMediator _mediator { get; set; }

        private string _input = "";
        private string _imgSrc = "";


        private async Task GenerateQRCode()
        {
            var qrCode = await _mediator.Send(new GenerateQRCodeCommand()
            {
                Code = _input.ToUpper()
            });
            _imgSrc = await _mediator.Send(new GetQRCodeBase64Command()
            {
                QRCode = qrCode
            });
        }
    }
}
