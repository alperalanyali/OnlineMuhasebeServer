using System;
using MediatR;

namespace Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
	public class CreateUCAFRequest:IRequest<CreateUCAFResponse>
	{

		public string Code { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
        public string CompanyId { get; set; }
    }
}

