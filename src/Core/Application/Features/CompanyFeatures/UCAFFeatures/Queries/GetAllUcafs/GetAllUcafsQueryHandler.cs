using System;
using Application.Messaging;
using Application.Services.CompanyServices;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUcafs
{
    public class GetAllUcafsQueryHandler : IQueryHandler<GetAllUcafsQuery, GetAllUcafsQueryResponse>
    {
        private readonly IUCAFService _ucafService;
        public GetAllUcafsQueryHandler(IUCAFService uCAFService)
        {
            _ucafService = uCAFService;
        }
        public async Task<GetAllUcafsQueryResponse> Handle(GetAllUcafsQuery request, CancellationToken cancellationToken)
        {
            var ucafs = await _ucafService.GetAllUCAFs(request.companyId,request.codeOrName,request.type);


            return new(ucafs.Count, ucafs);
        }
    }
}

