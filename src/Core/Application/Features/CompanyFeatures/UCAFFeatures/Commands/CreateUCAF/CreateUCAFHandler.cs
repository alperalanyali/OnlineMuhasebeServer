using System;
using Application.Services.CompanyServices;
using MediatR;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFHandler : IRequestHandler<CreateUCAFRequest, CreateUCAFResponse>
    {
        private readonly IUCAFService _ucafService;
        public CreateUCAFHandler(IUCAFService uCAFService)
        {
            _ucafService = uCAFService;
        }
        public async Task<CreateUCAFResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
        {
            await _ucafService.CreateUCAFAsync(request);

            return new();
        }
    }
}

