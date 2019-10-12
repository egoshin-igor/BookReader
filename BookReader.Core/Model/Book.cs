namespace BookReader.Core.Model
{
    public class Book
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int AuthorId { get; protected set; }
        public int GenreId { get; protected set; }

        protected Book()
        {

        }
    }
}
