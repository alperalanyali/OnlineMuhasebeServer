using System;
using Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.Configuration
{
	public sealed class BookEntryConfiguration: IEntityTypeConfiguration<BookEntry>
    {
		

        public void Configure(EntityTypeBuilder<BookEntry> builder)
        {
            builder.ToTable(TableNames.BookEntries);
            builder.HasKey(p => p.Id);
               
        }
    }
}

