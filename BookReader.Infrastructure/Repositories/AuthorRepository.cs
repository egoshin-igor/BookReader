using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;

namespace BookReader.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository( DbContext dbContext ) : base( dbContext )
        {
        }
    }
}
