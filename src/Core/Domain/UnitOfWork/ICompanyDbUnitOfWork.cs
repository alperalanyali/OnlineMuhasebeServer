using System;
using Microsoft.EntityFrameworkCore;

namespace Domain.UnitOfWork
{
	public interface ICompanyDbUnitOfWork :IUnitOfWork
    {
        void SetDbContextInst(DbContext context);
        
    }
}

