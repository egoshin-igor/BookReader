using BookReader.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure( EntityTypeBuilder<Book> builder )
        {
            builder.ToTable( nameof( Book ) ).HasKey( t => t.Id );

            builder.HasOne<Genre>()
                .WithMany()
                .HasForeignKey( b => b.GenreId );
            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey( b => b.AuthorId );
        }
    }
}
