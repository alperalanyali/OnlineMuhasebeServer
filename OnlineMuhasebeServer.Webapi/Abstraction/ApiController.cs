
using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMuhasebeServer.Webapi.Abstraction
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ApiController:ControllerBase
	{
		protected readonly IMediator _mediatR;

        public ApiController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
    }
}

