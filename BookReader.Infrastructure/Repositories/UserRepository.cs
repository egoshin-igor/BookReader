using System.Threading.Tasks;
using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using BookReader.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using MusicStore.Lib.Repositories;

namespace BookReader.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository( BookReaderDbContext dbContext ) : base( dbContext )
        {
        }

        public async Task<User> GetAsync( string login )
        {
            return await Entities.FirstOrDefaultAsync( e => e.Login == login );
        }

        public async Task<User> GetAsync( int id )
        {
            return await Entities.FirstOrDefaultAsync( e => e.Id == id );
        }
    }
}
