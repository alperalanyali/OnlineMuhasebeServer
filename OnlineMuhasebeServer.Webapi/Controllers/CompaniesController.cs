using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediatR) : base(mediatR)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand request)
        {
           CreateCompanyResponse response =  await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabase()
        {
            MigrateCompanyDatabaseCommand request = new();
            MigrateCompanyDatabaseResponse response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}

