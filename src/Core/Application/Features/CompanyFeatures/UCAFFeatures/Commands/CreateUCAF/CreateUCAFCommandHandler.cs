using System;
using Application.Services;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandHandler : IRequestHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;
        private readonly ILogService _logService;
        private readonly IApiService _apiService;
        public CreateUCAFCommandHandler(IUCAFService uCAFService,ILogService logService,IApiService apiService)
        {
            _ucafService = uCAFService;
            _logService = logService;
            _apiService = apiService;
        }
        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            if (request.Type == "A" ) throw new Exception("Hesap plani turu Grup ya da Muavin olmalidir!!");
            UCAF ucaf = await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);
            if (ucaf != null) throw new Exception("Bu hesap planı kodu daha önce tanımlanmış!");
            var userId = _apiService.GetUserIdByToken();
            var newUCaf = await _ucafService.CreateUCAFAsync(request, cancellationToken);
            Log log = new Log()
            {
                Id= Guid.NewGuid().ToString(),
                TableName ="UCAF",
                Progress="Create",
                UserId = userId,
                Data=JsonConvert.SerializeObject(newUCaf)

            };
            await _logService.AddAsync(log,request.CompanyId);
            return new();
        }
    }
}

