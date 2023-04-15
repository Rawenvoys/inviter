using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Commands.GetQRCodeBase64
{
    public class GetQRCodeBase64Command : IRequest<string>
    {
        public QRCodeData QRCode { get; set; }
    }
}
