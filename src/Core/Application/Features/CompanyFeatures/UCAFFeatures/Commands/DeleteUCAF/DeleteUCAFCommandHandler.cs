using System;
using Application.Messaging;
using Application.Services.CompanyServices;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.DeleteUCAF
{
    public class DeleteUCAFCommandHandler : ICommandHandler<DeleteUCAFCommand, DeleteUCAFCommandResponse>
    {


        private readonly IUCAFService _ucafService;

        public DeleteUCAFCommandHandler(IUCAFService ucafService)
        {
            _ucafService = ucafService;
        }

        public async Task<DeleteUCAFCommandResponse> Handle(DeleteUCAFCommand request, CancellationToken cancellationToken)
        {

            //var checkRemoveUcafById = await _ucafService.CheckRemoveUcafByIdIsGroupAvailable(request.Id, request.CompanyId);

            //if (!checkRemoveUcafById) throw new Exception("Hesap planına ait hesaplar oldugundan silinemiyor");

            await _ucafService.DeleteById(request.CompanyId,request.Id,cancellationToken);
            return new();
        }
    }
}

