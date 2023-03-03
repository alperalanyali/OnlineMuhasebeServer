using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using Application.Features.CompanyFeatures.BookEntryFeatures.Quries.GetAllBookEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Webapi.Abstraction;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMuhasebeServer.Webapi.Controllers
{
    public class BookEntryController : ApiController
    {
        public BookEntryController(IMediator mediatR) : base(mediatR)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateBookEntryCommand request, CancellationToken cancellationToken) {

            var response = await _mediatR.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllBoonEntries(GetAllBookEntriesQuery request){

            var response = await _mediatR.Send(request);
            return Ok(response);
        }
     }
}

