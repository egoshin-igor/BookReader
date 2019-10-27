using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;

namespace BookReader.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository( DbContext dbContext ) : base( dbContext )
        {
        }
    }
}
