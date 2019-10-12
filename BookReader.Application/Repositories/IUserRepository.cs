using System.Threading.Tasks;
using BookReader.Application.Entities.Users;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync( string email );
    }
}
