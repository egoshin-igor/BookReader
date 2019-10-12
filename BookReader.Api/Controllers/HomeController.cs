using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Api.Dtos;
using BookReader.Application.AppServices;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Api.Controllers
{
    [Route( "api/home" )]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController( IUnitOfWork unitOfWork, IAccountService accountService )
        {
            _unitOfWork = unitOfWork;
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
