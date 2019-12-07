using BookReader.Core.Types;

namespace BookReader.Application.Queries.Dto
{
    public class BookDto
    {
        public string Name { get; set; }
        public string JenreName { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public UserBookStatus Status { get; set; }
    }
}
