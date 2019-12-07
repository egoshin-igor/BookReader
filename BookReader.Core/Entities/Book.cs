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

        public Book(
            string name,
            int authorId,
            int genreId,
            string imagePath,
            string filePath
            )
        {
            Name = name;
            AuthorId = authorId;
            GenreId = genreId;
            ImagePath = imagePath;
            FilePath = filePath;
        }

        protected Book()
        {

        }
    }
}
