using System;
using System.Collections.Generic;
using System.Text;
using BookReader.Core.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure( EntityTypeBuilder<Book> builder )
        {
            builder.ToTable( nameof( Book ) ).HasKey( t => t.Id );
        }
    }
}
