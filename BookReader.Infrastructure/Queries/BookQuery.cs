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

        public BookQuery( BookReaderDbContext dbContext, IQueryable<UserBook> userBookQuery ) : base( dbContext )
        {
            _userBookQuery = userBookQuery;
        }

        public async Task<List<BookDto>> GetAll( int userId )
        {
            var query = from book in Query
                        join userBook in _userBookQuery on book.Id equals userBook.BookId
                        where userBook.UserId == userId
                        select new { book, userBook };
            var userBooks = await query.ToListAsync();


            return userBooks.ConvertAll( ub => new BookDto
            {
            } );
        }
    }
}
