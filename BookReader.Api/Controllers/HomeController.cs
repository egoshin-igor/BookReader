﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BookReader.Application.Queries;
using BookReader.Application.Queries.Dto;
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
        private readonly IBookQuery _bookQuery;
        private readonly IGenreQuery _genreQuery;

        public HomeController( IUnitOfWork unitOfWork, IBookQuery bookQuery, IGenreQuery genreQuery )
        {
            _unitOfWork = unitOfWork;
            _bookQuery = bookQuery;
            _genreQuery = genreQuery;
        }

        [HttpGet( "books" )]
        public async Task<List<BookDto>> GetBooksAsync()
        {
            return await _bookQuery.GetAll( UserId );
        }

        [HttpGet( "genres" )]
        public async Task<List<GenreDto>> GetGenresAsync()
        {
            return await _genreQuery.GetAll();
        }
    }
}
