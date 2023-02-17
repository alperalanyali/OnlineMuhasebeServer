using System;
using System.Text;
using System.Text.Json.Serialization;
using Application.Services;
using Domain.CompanyEntities;
using Domain.Dtos;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Infrastructure.Services
{
	public sealed class RabbitMQService:IRabbitMQService
	{
         public static string connectionString = "amqp://guest:guest@localhost:5672";



        public void SendQueueReport(ReportDto reportDto)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(connectionString);

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("Reports", true, false, false);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reportDto));
            channel.BasicPublish(String.Empty, "Reports",null,body);

        }
    }
}

