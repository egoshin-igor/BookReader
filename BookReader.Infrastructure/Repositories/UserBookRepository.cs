using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using BookReader.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;

namespace BookReader.Infrastructure.Repositories
{
    public class UserBookRepository : Repository<UserBook>, IUserBookRepository
    {
        public UserBookRepository( BookReaderDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
