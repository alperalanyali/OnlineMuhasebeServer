using System;
using Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.Configuration
{
    public sealed class UCAFConfiguration : IEntityTypeConfiguration<UCAF>
    {
        public void Configure(EntityTypeBuilder<UCAF> builder)
        {
            builder.ToTable(TableNames.UCAF);
            builder.HasKey(p => p.Id);
        }
    }
}

