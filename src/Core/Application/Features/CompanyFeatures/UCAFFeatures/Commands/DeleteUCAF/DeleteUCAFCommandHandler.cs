using System;
using Application.Messaging;
using Application.Services;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;
using Newtonsoft.Json;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.DeleteUCAF
{
    public class DeleteUCAFCommandHandler : ICommandHandler<DeleteUCAFCommand, DeleteUCAFCommandResponse>
    {


        private readonly IUCAFService _ucafService;
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        public DeleteUCAFCommandHandler(IUCAFService ucafService,ILogService logService,IApiService apiService)
        {
            _ucafService = ucafService;
            _logService = logService;
            _apiService = apiService;
        }

        public async Task<DeleteUCAFCommandResponse> Handle(DeleteUCAFCommand request, CancellationToken cancellationToken)
        {

            var checkRemoveUcafById = await _ucafService.CheckRemoveUcafByIdIsGroupAvailable(request.Id, request.CompanyId);

            if (!checkRemoveUcafById) throw new Exception("Hesap planına ait hesaplar oldugundan silinemiyor");

            UCAF ucaf =  await _ucafService.DeleteById(request.CompanyId,request.Id,cancellationToken);
            var userId = _apiService.GetUserIdByToken();
            Log log = new Log()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = "UCAF",
                Progress = "Delete",
                UserId = userId,
                Data = JsonConvert.SerializeObject(ucaf)
            };
            await _logService.AddAsync(log, request.CompanyId);
            return new();
        }
    }
}

