using System;
using Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.Configuration
{
	public sealed class LogConfiguration:IEntityTypeConfiguration<Log>
	{
		

        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable(TableNames.Logs);
            builder.HasKey(p => p.Id);
        }
    }
}

