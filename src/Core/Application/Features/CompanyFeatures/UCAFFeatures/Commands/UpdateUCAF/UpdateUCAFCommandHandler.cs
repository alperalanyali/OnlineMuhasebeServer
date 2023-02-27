using System;
using Application.Messaging;
using Application.Services;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;
using Newtonsoft.Json;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF
{
    public class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        public UpdateUCAFCommandHandler(IUCAFService ucafService,ILogService logService,IApiService apiService)
        {
            _ucafService = ucafService;
            _logService = logService;
            _apiService = apiService;
        }

        public async Task<UpdateUCAFCommandResponse> Handle(UpdateUCAFCommand request, CancellationToken cancellationToken)
        {
            var ucaf = await _ucafService.GetByIdAsync( request.Id,request.CompanyId);

            if (ucaf == null) throw new Exception("Hesap planı bulunamadı!");
            if (ucaf.Code != request.Code)
            {
                UCAF checkNewCode = await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);
                if (checkNewCode != null) throw new Exception("Bu hesap planı kodu daha önce kullanılmış!");
            }

            if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup ya da Muavin olmalıdır!");
            var userId = _apiService.GetUserIdByToken();
            Log oldLog = new Log
            {
                Id = Guid.NewGuid().ToString(),
                TableName = "UCAF",
                Progress = "UpdateOld",
                Data = JsonConvert.SerializeObject(ucaf),
                UserId = userId
            };
       
            ucaf.Type = request.Type == "G" ? "G" : "M";
            ucaf.Code = request.Code;
            ucaf.Name = request.Name;

            await _ucafService.Update(ucaf,request.CompanyId,cancellationToken);

            Log newLog = new Log
            {
                Id = Guid.NewGuid().ToString(),
                TableName="UCAF",
                Progress = "UpdateNew",
                Data = JsonConvert.SerializeObject(ucaf),
                UserId = userId
            };
            await _logService.AddAsync(oldLog, request.CompanyId);
            await _logService.AddAsync(newLog, request.CompanyId);
            return new();

        }
    }
}

