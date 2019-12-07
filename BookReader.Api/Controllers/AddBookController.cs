using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Api.Dtos;
using BookReader.Application.Queries;
using BookReader.Application.Queries.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Controllers
{
    [Route( "api/add-book" )]
    [ApiController]
    [Authorize]
    public class AddBookController : BaseController
    {
        private readonly IGenreQuery _genreQuery;

        public AddBookController( IGenreQuery genreQuery )
        {
            _genreQuery = genreQuery;
        }

        [HttpPost( "" )]
        public async Task AddBookAsync( [FromBody] AddBookDto addBookDto )
        {
            throw new NotImplementedException();
        }

        [HttpGet( "genres" )]
        public async Task<List<GenreDto>> GetGenres()
        {
            return await _genreQuery.GetAll();
        }
    }
}
