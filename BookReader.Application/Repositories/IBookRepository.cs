using BookReader.Core.Entities;
using MusicStore.Lib.Repositories.Abstractions;
using System.Threading.Tasks;

namespace BookReader.Application.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetAsync( int bookId );
    }
}
