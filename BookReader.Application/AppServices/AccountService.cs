using System;
using System.Threading.Tasks;
using BookReader.Application.AppServices.Entities;
using BookReader.Application.Repositories;

namespace BookReader.Application.AppServices
{
    public interface IAccountService
    {
        Task AuthenticateAsync( string email );
        Task<ConfirmResult> ConfirmAsync( string email, string loginToken );
    }

    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public Task AuthenticateAsync( string email )
        {
            throw new NotImplementedException();
        }

        public Task<ConfirmResult> ConfirmAsync( string email, string loginToken )
        {
            throw new NotImplementedException();
        }

        //public async Task AuthenticateAsync( string email )
        //{
        //    string loginToken = Guid.NewGuid().ToString();

        //    var user = await _userRepository.GetAsync( email );
        //    if ( user == null )
        //    {
        //        user = new User( email, UserRole.User );
        //        _userRepository.Add( user );
        //        _eventBus.Publish( new UserHasBeenAdded { Email = email } );
        //    }
        //    user.UpdateLoginToken( loginToken );

        //    _eventBus.Publish( new UserAuthenticated { Email = email, LoginToken = loginToken } );
        //}

        //public async Task<ConfirmResult> ConfirmAsync( string email, string loginToken )
        //{
        //    ClaimsIdentity identity = await GetIdentityAsync( email, loginToken );
        //    if ( identity == null )
        //        return null;

        //    var utcNow = DateTime.UtcNow;
        //    var jwt = new JwtSecurityToken(
        //            issuer: AuthOptions.Issuer,
        //            audience: AuthOptions.Audience,
        //            notBefore: utcNow,
        //            claims: identity.Claims,
        //            expires: utcNow.Add( TimeSpan.FromDays( AuthOptions.LifeTimeInDays ) ),
        //            signingCredentials: new SigningCredentials( AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256 ) );
        //    string encodedJwt = new JwtSecurityTokenHandler().WriteToken( jwt );

        //    string userRole = identity.Claims.First( i => i.Type == ClaimsIdentity.DefaultRoleClaimType ).Value;
        //    return new ConfirmResult { AccessToken = encodedJwt, RefreshToken = "", UserRole = userRole };
        //}

        //private async Task<ClaimsIdentity> GetIdentityAsync( string email, string loginToken )
        //{
        //    User user = await _userRepository.GetAsync( email );
        //    if ( user == null )
        //        return null;
        //    if ( !user.IsValidLoginToken( loginToken ) )
        //        return null;

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
        //        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        //    };

        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(
        //        claims,
        //        "Token",
        //        ClaimsIdentity.DefaultNameClaimType,
        //        ClaimsIdentity.DefaultRoleClaimType
        //    );

        //    return claimsIdentity;
        //}
    }
}
