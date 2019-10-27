using BookReader.Core.Entities;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Application.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
