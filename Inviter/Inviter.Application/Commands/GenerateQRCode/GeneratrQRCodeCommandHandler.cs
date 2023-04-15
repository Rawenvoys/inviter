using Microsoft.Extensions.Configuration;
using QRCoder;

namespace Inviter.Application.Commands.GenerateQRCode
{
    public class GeneratrQRCodeCommandHandler : IRequestHandler<GenerateQRCodeCommand, QRCodeData>
    {
        private readonly string _baseUrl;
        public GeneratrQRCodeCommandHandler(IConfiguration configuration)
        {
            _baseUrl = configuration["InviterWebGuestBaseUrl"] ?? throw new Exception();
        }

        public async Task<QRCodeData> Handle(GenerateQRCodeCommand request, CancellationToken cancellationToken)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string url = $"{_baseUrl}/{request.Code}";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            return await Task.FromResult(qrCodeData);
        }
    }
}
