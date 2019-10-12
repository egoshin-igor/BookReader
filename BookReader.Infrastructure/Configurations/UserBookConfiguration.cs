using BookReader.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Infrastructure.Configurations
{
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure( EntityTypeBuilder<UserBook> builder )
        {
            builder.ToTable( nameof( UserBook ) ).HasKey( t => t.Id );

            builder
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey( uB => uB.BookId );

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey( uB => uB.UserId );
        }
    }
}
