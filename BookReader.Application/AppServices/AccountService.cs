using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using BookReader.Application.AppServices.Dtos;
using BookReader.Application.Entities.Users;
using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BookReader.Application.AppServices
{
    public interface IAccountService
    {
        Task<bool> RegistrateAsync( RegistrationRequestDto registrationRequest );
        Task<UserTokenDto> Auth( string login, string password );
        Task<UserTokenDto> UpdateTokens( string refreshToken );
    }

    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService( IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegistrateAsync( RegistrationRequestDto registrationRequest )
        {
            var user = await _userRepository.GetAsync( registrationRequest.Login );
            if ( user != null )
                return false;

            user = new User(
                registrationRequest.FirstName,
                registrationRequest.LastName,
                registrationRequest.Login,
                registrationRequest.Email,
                registrationRequest.Password
            );
            _userRepository.Add( user );

            return true;
        }

        public async Task<UserTokenDto> Auth( string login, string password )
        {
            User user = await _userRepository.GetAsync( login );
            if ( user.Password != password )
                return null;

            return GenerateToken( user );
        }

        public async Task<UserTokenDto> UpdateTokens( string refreshToken )
        {
            string[] tokenInfos = refreshToken.Split( '|' );
            if ( tokenInfos.Length != 2 )
                return null;
            string refreshTokenPart = tokenInfos[ 1 ];

            int userId;
            if ( !int.TryParse( refreshTokenPart, out userId ) )
                return null;

            User user = await _userRepository.GetAsync( userId );
            if ( user == null || user.RefreshToken != refreshToken )
                return null;

            return GenerateToken( user );
        }

        private UserTokenDto GenerateToken( User user )
        {
            ClaimsIdentity identity = GetIdentity( user );

            var utcNow = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    notBefore: utcNow,
                    claims: identity.Claims,
                    expires: utcNow.Add( TimeSpan.FromMinutes( AuthOptions.LifeTimeInMinutes ) ),
                    signingCredentials: new SigningCredentials( AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256 ) );
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken( jwt );

            string refreshToken = Guid.NewGuid().ToString();
            user.UpdateRefreshToken( refreshToken );
            return new UserTokenDto { AccessToken = encodedJwt, RefreshToken = $"{user.Id}|{refreshToken}" };
        }

        private ClaimsIdentity GetIdentity( User user )
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, UserRole.User)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType
            );

            return claimsIdentity;
        }
    }
}
