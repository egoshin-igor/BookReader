using System;
using System.Threading.Tasks;
using BookReader.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Controllers
{
    [Route( "api/reading" )]
    [ApiController]
    [Authorize]
    public class BookReadingController : BaseController
    {
        [HttpGet( "detail" )]
        public Task<DetailBookDto> GetDetails( [FromQuery] int bookId )
        {
            throw new NotImplementedException();
        }

        [HttpPost( "save-book-note" )]
        public Task SaveBookNote( [FromBody] BookNoteDto bookNoteDto )
        {
            throw new NotImplementedException();
        }
    }
}
