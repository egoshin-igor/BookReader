namespace BookReader.Core.Entities
{
    public class User
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Login { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string RefreshToken { get; protected set; }

        protected User()
        {
        }

        public User(
            string firstName,
            string lastName,
            string login,
            string email,
            string password )
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Email = email;
        }

        public void UpdateRefreshToken( string refreshToken )
        {
            RefreshToken = refreshToken;
        }
    }
}
