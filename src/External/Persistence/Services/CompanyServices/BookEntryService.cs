using System;
using Application.Services.CompanyServices;
using Domain;
using Domain.CompanyEntities;
using Domain.Dtos;
using Domain.Repository.CompanyDbContext.BookEntryRepositories;
using Domain.UnitOfWork;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services.CompanyServices
{
    public class BookEntryService : IBookEntryService
    {
        private CompanyDbContext context;
        private readonly IContextService _contextService;
        private readonly IBookEntryCommandRepository _bookCommand;
        private readonly IBookEntryQueryRepository _bookQuery;
        private readonly ICompanyDbUnitOfWork _companyUnitOfWork;

        public BookEntryService(IContextService contextService, IBookEntryCommandRepository bookEntryCommand, IBookEntryQueryRepository bookEntryQueryRepository, ICompanyDbUnitOfWork companyDbUnitOfWork)
        {
            _contextService = contextService;
            _bookCommand = bookEntryCommand;
            _bookQuery = bookEntryQueryRepository;
            _companyUnitOfWork = companyDbUnitOfWork;
        }

        public async Task AddAsync(string companyId, BookEntry bookEntry, CancellationToken cancellationToken)
        {
            context = (CompanyDbContext)_contextService.CreateDBContextInstance(companyId);
            _bookCommand.SetDbContextInst(context);
            _companyUnitOfWork.SetDbContextInst(context);
            await _bookCommand.AddAsync(bookEntry, cancellationToken);
            await _companyUnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<string> GetNewBookEntryNumber(string companyId)
        {
            context = (CompanyDbContext)_contextService.CreateDBContextInstance(companyId);
            _bookQuery.SetDbContextInst(context);
            _companyUnitOfWork.SetDbContextInst(context);
            BookEntry lastBookEntry = await _bookQuery.GetAll().OrderByDescending(p => p.CreatedDate).FirstOrDefaultAsync();

            if (lastBookEntry is null)
            {
                return "0000000000000001";
            }
            long lastBookEntryNumber = Convert.ToInt64(lastBookEntry.BookEntryNumber);
            lastBookEntryNumber++;

            string newBookEntryNumber = lastBookEntryNumber.ToString();
            for (int i = newBookEntryNumber.Length; i <16 ; i++)
            {
                newBookEntryNumber = "0" + newBookEntryNumber;
            }

            return newBookEntryNumber;
        }

        public async Task<PaginationResult<BookEntry>> GetAllAsync(string companyId, int pageNumber, int pageSize,int year)
        {
            context = (CompanyDbContext)_contextService.CreateDBContextInstance(companyId);
            _bookQuery.SetDbContextInst(context);

            string startingDateString = "01.01." + year;
            string endDateString = "31.12." + year;

            return await _bookQuery.GetWhere(p => p.Date>= Convert.ToDateTime(startingDateString) && p.Date <= Convert.ToDateTime(endDateString) ).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(pageNumber,
            pageSize);
        }

        public int GetCount(string companyId)
        {
            context = (CompanyDbContext)_contextService.CreateDBContextInstance(companyId);
            _bookQuery.SetDbContextInst(context);
            var count = _bookQuery.GetAll().Count();

            return count;
        }
    }
}

