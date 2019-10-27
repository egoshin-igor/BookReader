using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BookReader.Application.Entities.Users
{
    public class AuthOptions
    {
        const string Key = "my_very_secret_which_is_not_secret";   // ключ для шифрации

        public const string Issuer = "BookReader";
        public const string Audience = "BookReader";
        public const int LifeTimeInMinutes = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey( Encoding.ASCII.GetBytes( Key ) );
        }
    }
}
