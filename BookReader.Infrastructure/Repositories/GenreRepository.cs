using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using BookReader.Infrastructure.Foundation;
using MusicStore.Lib.Repositories;

namespace BookReader.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository( BookReaderDbContext dbContext ) : base( dbContext )
        {
        }
    }
}
