using System.Threading.Tasks;
using BookReader.Application.Entities.Users;
using BookReader.Core.Entities;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync( string login );
        Task<User> GetAsync( int id );
    }
}
