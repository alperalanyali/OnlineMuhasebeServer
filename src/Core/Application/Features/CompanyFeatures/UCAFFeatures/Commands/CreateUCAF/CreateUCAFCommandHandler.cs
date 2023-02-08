using System;
using Application.Services.CompanyServices;
using MediatR;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandHandler : IRequestHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;
        public CreateUCAFCommandHandler(IUCAFService uCAFService)
        {
            _ucafService = uCAFService;
        }
        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            if (request.Type == "A" ) throw new Exception("Hesap plani turu Grup ya da Muavin olmalidir!!");

            await _ucafService.CreateUCAFAsync(request, cancellationToken);

            return new();
        }
    }
}

