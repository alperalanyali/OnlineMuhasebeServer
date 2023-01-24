using System;
using Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.UCAFRepositories
{
    public interface IUCAFCommandRepository : ICommandRepository<UCAF>
    {
      
    }
}

