using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookReader.Api.Dtos;
using BookReader.Application.AppServices;
using BookReader.Application.AppServices.Entities;
using BookReader.Application.Queries;
using BookReader.Application.Queries.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookReader.Api.Controllers
{
    [Route( "api/add-book" )]
    [ApiController]
    [Authorize]
    public class AddBookController : BaseController
    {
        private readonly IGenreQuery _genreQuery;
        private readonly IBookService _bookService;

        public AddBookController( IGenreQuery genreQuery, IBookService bookService )
        {
            _genreQuery = genreQuery;
            _bookService = bookService;
        }

        [HttpPost( "" ), DisableRequestSizeLimit]
        public async Task AddBookAsync()
        {
            IFormFileCollection files = Request.Form.Files;
            AddBookDto draftDddBookDto = JsonConvert.DeserializeObject<AddBookDto>( Request.Form[ "data" ] );

            var addBookDto = new Application.AppServices.Dtos.AddBookDto
            {
                Author = draftDddBookDto.Author,
                GenreId = draftDddBookDto.GenreId,
                Name = draftDddBookDto.Name,
                BookFile = await FormFileAdapter.CreateAsync( files[ 0 ] ),
                Image = await FormFileAdapter.CreateAsync( files[ 1 ] ),
                UserId = UserId
            };

            await _bookService.AddBookAsync( addBookDto );
        }

        [HttpGet( "genres" )]
        public async Task<List<GenreDto>> GetGenres()
        {
            return await _genreQuery.GetAll();
        }
    }
}
