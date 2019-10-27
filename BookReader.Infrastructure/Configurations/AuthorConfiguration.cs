using BookReader.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure( EntityTypeBuilder<Author> builder )
        {
            builder.ToTable( nameof( Author ) ).HasKey( t => t.Id );
        }
    }
}
