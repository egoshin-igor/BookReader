﻿using BookReader.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookReader.Infrastructure.Foundation
{
    public class BookReaderDbContext : DbContext
    {
        public BookReaderDbContext( DbContextOptions<BookReaderDbContext> options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration( new BookConfiguration() );
            builder.ApplyConfiguration( new AuthorConfiguration() );
            builder.ApplyConfiguration( new GenreConfiguration() );
            builder.ApplyConfiguration( new UserBookConfiguration() );
            builder.ApplyConfiguration( new UserConfiguration() );
        }
    }
}
