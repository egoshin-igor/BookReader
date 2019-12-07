using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Application.Queries.Dto;

namespace BookReader.Application.Queries
{
    public interface IGenreQuery
    {
        Task<List<GenreDto>> GetAll();
    }
}
