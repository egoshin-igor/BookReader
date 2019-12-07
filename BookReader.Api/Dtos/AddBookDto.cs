namespace BookReader.Api.Dtos
{
    public class AddBookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
    }
}
