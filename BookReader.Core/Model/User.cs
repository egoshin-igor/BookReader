namespace BookReader.Core.Model
{
    public class User
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Login { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        protected User()
        {

        }
    }
}
