using System.Threading.Tasks;
using BookReader.Application.AppServices;
using BookReader.Application.AppServices.Entities;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Api.Controllers
{
    [Route( "api/account" )]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        public AccountController( IUnitOfWork unitOfWork, IAccountService accountService )
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }

        [HttpPost, Route( "auth" )]
        public async Task<IActionResult> Auth( [FromBody] string email )
        {
            await _accountService.AuthenticateAsync( email );
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpPost, Route( "confirm" )]
        public async Task<IActionResult> ConfirmAsync( [FromQuery] string email, [FromQuery] string loginToken )
        {
            ConfirmResult result = await _accountService.ConfirmAsync( email, loginToken );
            if ( result == null )
            {
                return BadRequest();
            }

            return Ok( result );
        }
    }
}
