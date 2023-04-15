using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Commands.GetQRCodeBase64
{
    internal class GetQRCodeBase64CommandHandler : IRequestHandler<GetQRCodeBase64Command, string>
    {
        public async Task<string> Handle(GetQRCodeBase64Command request, CancellationToken cancellationToken)
        {
            Base64QRCode qrCodeBase64 = new Base64QRCode(request.QRCode);
            string graphic = qrCodeBase64.GetGraphic(20, "#063282", "#FFFFFF", true, Base64QRCode.ImageType.Jpeg);
            return await Task.FromResult($"data:image/jpeg;base64,{graphic}");
        }
    }
}
