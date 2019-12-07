using BookReader.Application.Queries.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookReader.Application.Queries
{
    public interface IBookQuery
    {
        Task<List<BookDto>> GetAll( int userId );
    }
}
