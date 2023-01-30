using System;
using Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.CompanyDbContext.UCAFRepositories
{
    public interface IUCAFCommandRepository : ICompanyDbCommandRepository<UCAF>
    {
      
    }
}

