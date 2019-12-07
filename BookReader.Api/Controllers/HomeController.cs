using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Api.Controllers
{
    [Route( "api/home" )]
    [ApiController]
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController( IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet( "my-name" )]
        public async Task<int> GetMyName()
        {
            var id = UserId;
            return UserId;
        }

        [HttpGet( "books" )]
        public async Task<List<BookDto>> GetBooksAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet( "genres" )]
        public async Task<List<GenreDto>> GetGenresAsync()
        {
            throw new NotImplementedException();
        }
    }
}
