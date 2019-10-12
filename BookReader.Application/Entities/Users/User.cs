namespace BookReader.Application.Entities.Users
{
    public class User
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
    }
}
