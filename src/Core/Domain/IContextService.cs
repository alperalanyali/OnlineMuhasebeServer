using System;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
	public interface IContextService
	{
		DbContext CreateDBContextInstance(string companyId);
	}
}

