using System;
using Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using Application.Services;
using Application.Services.CompanyServices;
using Azure.Core;
using Domain;
using Domain.CompanyEntities;
using Domain.Dtos;
using Domain.Repository.CompanyDbContext.ReportRepositories;
using Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services.CompanyServices
{
    public class ReportService : IReportService
    {
        private CompanyDbContext _context;
        private readonly IContextService _contextService;
        private readonly IReportCommandRepository _reportCommandRepo;
        private readonly IReportQueryRepository _reportQueryRepo;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IRabbitMQService _rabbitMQService;
        public ReportService(IContextService contextService,IReportCommandRepository reportCommandRepository,IReportQueryRepository reportQueryRepository,ICompanyDbUnitOfWork unitOfWork,IRabbitMQService rabbitMQService)
        {
            _contextService = contextService;
            _reportCommandRepo = reportCommandRepository;
            _reportQueryRepo = reportQueryRepository;
            _unitOfWork = unitOfWork;
            _rabbitMQService = rabbitMQService;
        }


        public async Task<PaginationResult<Report>> GetAllReportsByCompanyId(string companyId,int pageNumber =1,int pageSize=5)
        {
            _context = (CompanyDbContext)_contextService.CreateDBContextInstance(companyId);
            _reportQueryRepo.SetDbContextInst(_context);
            var result = await _reportQueryRepo.GetAllPagination(pageNumber,pageSize);           
            result.Datas.OrderByDescending(p => p.CreatedDate);
            return result;
        }


        public async Task Request(RequestReportCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDBContextInstance(request.CompanyId);
            _reportCommandRepo.SetDbContextInst(_context);
            _unitOfWork.SetDbContextInst(_context);

            Report report = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Status = false,
                FileUrl = ""

            };
            await _reportCommandRepo.AddAsync(report, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            SenQueue(report, request.CompanyId);


        }

        public void SenQueue(Report report,string companyId)
        {
            ReportDto reporDto = new()
            {
                Id = report.Id,
                CompanyId = companyId,
                Name = report.Name

            };
            _rabbitMQService.SendQueueReport(reporDto);
        }
    }
}

