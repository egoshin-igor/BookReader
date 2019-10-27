using System;
using System.Threading.Tasks;
using BookReader.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Controllers
{
    [Route( "api/add-book" )]
    [ApiController]
    [Authorize]
    public class AddBookController : ControllerBase
    {
        [HttpPost( "" )]
        public async Task AddBookAsync( [FromBody] AddBookDto addBookDto )
        {
            throw new NotImplementedException();
        }
    }
}
