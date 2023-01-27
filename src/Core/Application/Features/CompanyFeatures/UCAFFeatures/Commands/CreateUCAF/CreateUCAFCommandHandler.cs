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
            await _ucafService.CreateUCAFAsync(request);

            return new();
        }
    }
}

