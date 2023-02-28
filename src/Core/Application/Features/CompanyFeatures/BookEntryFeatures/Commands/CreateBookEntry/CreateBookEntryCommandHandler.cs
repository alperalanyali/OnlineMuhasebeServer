using System;
using Application.Messaging;
using Application.Services;
using Application.Services.CompanyServices;
using Domain.CompanyEntities;
using Newtonsoft.Json;

namespace Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry
{
	public class CreateBookEntryCommandHandler:ICommandHandler<CreateBookEntryCommand,CreateBookEntryCommandResponse>
	{
		private readonly IBookEntryService _bookEntryService;
		private readonly ILogService _logService;
		private readonly IApiService _apiService;

		public CreateBookEntryCommandHandler(IBookEntryService bookEntryService,ILogService logService,IApiService apiService)
		{
			_bookEntryService = bookEntryService;
			_logService = logService;
			_apiService = apiService;
		}

        public async Task<CreateBookEntryCommandResponse> Handle(CreateBookEntryCommand request, CancellationToken cancellationToken)
        {
			string newBookEntryNumber = await _bookEntryService.GetNewBookEntryNumber(request.CompanyId);
			BookEntry newBookEntry = new BookEntry(newBookEntryNumber, Convert.ToDateTime(request.Date), request.Type,request.Description);

			await _bookEntryService.AddAsync(request.CompanyId, newBookEntry, cancellationToken);

			string userId = _apiService.GetUserIdByToken();
			Log newLog = new Log()
			{
				Id = Guid.NewGuid().ToString(),
				TableName = nameof(BookEntry),
				Progress = "Create",
				Data = JsonConvert.SerializeObject(newBookEntry),
				UserId = userId
			};
			await _logService.AddAsync(newLog, request.CompanyId);

			return new();
        }
    }
}

