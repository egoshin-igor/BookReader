namespace BookReader.Api.Dtos
{
    public class AddBookDto
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public byte[] Image { get; set; }
        public byte[] BookFile { get; set; }
    }
}
