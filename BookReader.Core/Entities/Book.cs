namespace BookReader.Core.Entities
{
    public class Book
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int AuthorId { get; protected set; }
        public int GenreId { get; protected set; }
        public string ImagePath { get; protected set; }
        public string FilePath { get; protected set; }

        protected Book()
        {

        }
    }
}
