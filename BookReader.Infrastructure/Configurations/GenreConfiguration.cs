using BookReader.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Infrastructure.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure( EntityTypeBuilder<Genre> builder )
        {
            builder.ToTable( nameof( Genre ) ).HasKey( t => t.Id );
        }
    }
}
