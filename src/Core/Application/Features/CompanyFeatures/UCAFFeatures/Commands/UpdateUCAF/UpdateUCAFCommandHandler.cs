using System;
using Application.Messaging;
using Application.Services.CompanyServices;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF
{
    public class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;

        public UpdateUCAFCommandHandler(IUCAFService ucafService)
        {
            _ucafService = ucafService;
        }

        public async Task<UpdateUCAFCommandResponse> Handle(UpdateUCAFCommand request, CancellationToken cancellationToken)
        {
            var ucaf = await _ucafService.GetById(request.CompanyId, request.Id);
            ucaf.Code = request.Code;
            ucaf.Name = request.Name;

            await _ucafService.Update(ucaf,request.CompanyId,cancellationToken);

            return new();

        }
    }
}

