using System;
using Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName;
using Application.Services.CompanyServices;
using Domain;
using Domain.AppEntities.Identity;
using Domain.CompanyEntities;
using Domain.Dtos;
using Domain.Repository.CompanyDbContext.LogRepositories;
using Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Persistence.Repositories.CompanyDbContext.LogRepositories;


namespace Persistence.Services.CompanyServices
{
	public class LogService:ILogService
	{
        private CompanyDbContext _context;
        private readonly IContextService _contextService;
        private readonly ICompanyDbUnitOfWork _companyUnitOfWork;
        private readonly ILogCommandRepository _logCommand;
        private readonly ILogQueryRepository _logQuery;
        private readonly UserManager<AppUser> _userManager;


        public LogService(IContextService contextService, ILogCommandRepository logCommandRepository, ILogQueryRepository logQueryRepository, ICompanyDbUnitOfWork companyDbUnitOfWork, UserManager<AppUser> userManager)
        {
            _contextService = contextService;
            _logCommand = logCommandRepository;
            _logQuery = logQueryRepository;
            _companyUnitOfWork = companyDbUnitOfWork;
            _userManager = userManager; 
        }


        public async Task AddAsync(Log log, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDBContextInstance(companyId);
            _logCommand.SetDbContextInst(_context);
            _companyUnitOfWork.SetDbContextInst(_context);


            await _logCommand.AddAsync(log,default);
            await _companyUnitOfWork.SaveChangesAsync(default);
        }

        public async Task<PaginationResult<LogDto>> GetLogsByTableNameQuery(GetLogsByTableNameQuery request)
        {
            _context = (CompanyDbContext)_contextService.CreateDBContextInstance(request.CompanyId);
            _logQuery.SetDbContextInst(_context);

             PaginationResult< Log> result = await _logQuery.GetAll(false).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(request.PageNumber, request.PageSize);

            IList<LogDto> logDtos = new List<LogDto>();
            int count = _logQuery.GetAll().Count();
            if (result.Datas != null)
            {
                foreach (var item in result.Datas)
                {
                    AppUser user = await _userManager.FindByIdAsync(item.UserId);
                    LogDto logDto = new()
                    {
                        Id = item.Id,
                        CreatedDate = item.CreatedDate,
                        Data = item.Data,
                        TableName = item.TableName,
                        Progress = item.Progress,
                        UserId = item.UserId,
                        UserEmail = user?.Email,
                        UserName = user?.FullName
                    };
                    logDtos.Add(logDto);
                }
            }


            PaginationResult<LogDto> requestResult = new(
                pageNumber: result.PageNumber,
                pageSize: result.PageSize,
                totalCount: count,
                datas: logDtos);

            return requestResult;
        }
    }
}

