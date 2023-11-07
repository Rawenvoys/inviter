using Inviter.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Application.Commands.GetImages
{
    public class GetImagesCommandHandler : IRequestHandler<GetImagesCommand, List<Image>>
    {
        private readonly IImageFinder _imageFinder;
        public GetImagesCommandHandler(IImageFinder imageFinder) => _imageFinder = imageFinder;

        public Task<List<Image>> Handle(GetImagesCommand request, CancellationToken cancellationToken) 
            => _imageFinder.Get();
    }
}
