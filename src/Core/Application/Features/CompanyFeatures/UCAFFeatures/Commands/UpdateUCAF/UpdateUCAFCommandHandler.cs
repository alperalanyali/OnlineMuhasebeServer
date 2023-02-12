using System;
using Application.Messaging;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;

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
            var ucaf = await _ucafService.GetByIdAsync(request.CompanyId, request.Id);

            if (ucaf == null) throw new Exception("Hesap planı bulunamadı!");
            if (ucaf.Code != request.Code)
            {
                UCAF checkNewCode = await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);
                if (checkNewCode != null) throw new Exception("Bu hesap planı kodu daha önce kullanılmış!");
            }

            if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup ya da Muavin olmalıdır!");
       


            ucaf.Type = request.Type == "G" ? "G" : "M";
            ucaf.Code = request.Code;
            ucaf.Name = request.Name;

            await _ucafService.Update(ucaf,request.CompanyId,cancellationToken);

            return new();

        }
    }
}

