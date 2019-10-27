using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using BookReader.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;

namespace BookReader.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository( BookReaderDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
