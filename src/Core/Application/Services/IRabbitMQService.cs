using System;
using Domain.CompanyEntities;
using Domain.Dtos;

namespace Application.Services
{
	public interface IRabbitMQService
	{
       void SendQueueReport(ReportDto reportDto);
    }
}

