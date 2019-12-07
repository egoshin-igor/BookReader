using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using BookReader.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;
using System.Threading.Tasks;

namespace BookReader.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository( BookReaderDbContext dbContext ) : base( dbContext )
        { 
        }

        public async Task<Book> GetAsync( int bookId )
        {
            return await Entities.FirstOrDefaultAsync( b => b.Id == bookId );
        }
    }
}
