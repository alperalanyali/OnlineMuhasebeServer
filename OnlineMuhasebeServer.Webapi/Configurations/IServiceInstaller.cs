using System;
namespace OnlineMuhasebeServer.Webapi.Configurations
{
	public interface IServiceInstaller
	{

		void Install(IServiceCollection services, IConfiguration configuration);
	}
}

