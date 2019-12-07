using BookReader.Application.AppServices.Entities;

namespace BookReader.Application.AppServices.Dtos
{
    public class AddBookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int GenreId { get; set; }
        public FormFileAdapter Image { get; set; }
        public FormFileAdapter BookFile { get; set; }
    }
}
