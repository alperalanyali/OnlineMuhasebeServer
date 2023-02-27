using System;
using Application.Messaging;
using Application.Services.CompanyServices;

namespace Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName
{
    public class GetLogsByTableNameQueryHandler : IQueryHandler<GetLogsByTableNameQuery, GetLogsByTableNameQueryResponse>
    {
        private readonly ILogService _logService;
        public GetLogsByTableNameQueryHandler(ILogService logService)
        {
            _logService = logService;
        }
        public async Task<GetLogsByTableNameQueryResponse> Handle(GetLogsByTableNameQuery request, CancellationToken cancellationToken)
        {
            return new(await _logService.GetLogsByTableNameQuery(request));
        }
    }
}

