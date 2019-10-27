using System.Threading.Tasks;
using BookReader.Api.Dtos;
using BookReader.Application.AppServices;
using BookReader.Application.AppServices.Dtos;
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

        [HttpPost, Route( "registrate" )]
        public async Task<IActionResult> Registrate( [FromBody] RegistrationRequestDto registrationRequest )
        {
            bool isSuccessfulRegistration = await _accountService.RegistrateAsync( registrationRequest );
            if ( !isSuccessfulRegistration )
                return null;

            await _unitOfWork.CommitAsync();

            UserTokenDto userToken = await _accountService.Auth( registrationRequest.Login, registrationRequest.Password );

            await _unitOfWork.CommitAsync();

            return Ok( userToken );
        }

        [HttpPost, Route( "auth" )]
        public async Task<IActionResult> Auth( [FromBody] AuthRequestDto authRequestDto )
        {
            UserTokenDto userToken = await _accountService.Auth( authRequestDto.Login, authRequestDto.Password );

            return Ok( userToken );
        }

        [HttpPost( "update-tokens" )]
        public async Task<IActionResult> UpdateTokens( string refreshToken )
        {
            UserTokenDto userToken = await _accountService.UpdateTokens( refreshToken );

            return Ok( userToken );
        }
    }
}
