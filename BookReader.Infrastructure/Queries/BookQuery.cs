using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Application.Queries;
using BookReader.Application.Queries.Dto;
using BookReader.Infrastructure.Foundation;
using MusicStore.Lib.Queries.Abstractions;
using Microsoft.EntityFrameworkCore;
using BookReader.Core.Entities;
using System.Linq;

namespace BookReader.Infrastructure.Queries
{
    public class BookQuery : BaseQuery<Book>, IBookQuery
    {
        private IQueryable<UserBook> _userBookQuery;
        private IQueryable<Author> _authorQuery;
        private IQueryable<Genre> _genreQuery;

        public BookQuery( BookReaderDbContext dbContext ) : base( dbContext )
        {
            _userBookQuery = dbContext.Set<UserBook>().AsNoTracking();
            _authorQuery = dbContext.Set<Author>().AsNoTracking(); 
            _genreQuery = dbContext.Set<Genre>().AsNoTracking(); 
        }

        public async Task<List<BookDto>> GetAll( int userId )
        {
            var query = from book in Query
                        join userBook in _userBookQuery on book.Id equals userBook.BookId
                        join author in _authorQuery on book.AuthorId equals author.Id
                        join genre in _genreQuery on book.GenreId equals genre.Id
                        where userBook.UserId == userId
                        select new { book, userBook, author, genre };

            var userBooks = await query.ToListAsync();
            
            return userBooks.ConvertAll( ub => new BookDto
            {
                Id = ub.book.Id,
                Author = ub.author.Name,
                Name = ub.book.Name,
                ImagePath = ub.book.ImagePath,
                FilePath = ub.book.FilePath,
                JenreName = ub.genre.Name,
                Status = ub.userBook.Status
            } );
        }
    }
}
