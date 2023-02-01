using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AppFeatures.UserCompanyFeatures.Commands.CreateUserCompany;
using Application.Features.AppFeatures.UserCompanyFeatures.Commands.DeleteUserCompany;
using Application.Features.AppFeatures.UserCompanyFeatures.Commands.UpdateUserCompany;
using Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetAllUserCompany;
using Application.Features.AppFeatures.UserCompanyFeatures.Queries.GetUserCompanyByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class UserCompanyController : ApiController
    {
        public UserCompanyController(IMediator mediatR) : base(mediatR)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserCompanyCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllUserCompanyCommand();
            var response = await _mediatR.Send(request);
            return Ok(response);

        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateUserCompanyCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(DeleteUserCompanyCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserCompanyByUserId(GetUserCompanyByUserIdCommand request)
        {
            var response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}

