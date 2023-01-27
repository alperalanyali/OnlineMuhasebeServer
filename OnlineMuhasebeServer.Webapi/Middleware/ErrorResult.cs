using System;
using Newtonsoft.Json;

namespace OnlineMuhasebeServer.Webapi.Middleware
{
	public class ErrorResult:ErrorStatusCode
	{
		
		public string ErrorMessage { get; set; }
		public string TechnicalMessage { get; set; }

	
    }

	public class ErrorStatusCode
	{
		public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

	public class ValidationErrorDetail:ErrorStatusCode
	{
		public IEnumerable<string> Errors { get; set; }
   
    }
}

