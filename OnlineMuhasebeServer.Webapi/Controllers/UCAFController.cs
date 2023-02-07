using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateMainUCAF;
using Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUcafs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class UCAFController : ApiController
    {
        public UCAFController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCAF(CreateUCAFCommand request,CancellationToken cancellationToken)
        {
            CreateUCAFCommandResponse response = await _mediatR.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMainUCAF(CreateMainUCAFCommand request,CancellationToken cancellationToken)
        {
            CreateMainUCAFCommandResponse response = await _mediatR.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUcafs(string companyId,string codeOrName=null,string type=null)
        {
            var request = new GetAllUcafsQuery(companyId,codeOrName,type);
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}

