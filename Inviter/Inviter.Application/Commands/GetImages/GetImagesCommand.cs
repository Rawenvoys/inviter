using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Commands.GetImages
{
    public class GetImagesCommand : IRequest<List<Image>>
    {
    }
}
