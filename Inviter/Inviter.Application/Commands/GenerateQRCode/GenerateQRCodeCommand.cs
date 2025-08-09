using QRCoder;

namespace Inviter.Application.Commands.GenerateQRCode
{
    public class GenerateQRCodeCommand : IRequest<QRCodeData>
    {
        public string Code { get; set; }
    }
}
