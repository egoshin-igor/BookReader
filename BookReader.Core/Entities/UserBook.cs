using System;
using BookReader.Core.Types;

namespace BookReader.Core.Entities
{
    public class UserBook
    {
        public int Id { get; protected set; }
        public int BookId { get; protected set; }
        public int UserId { get; protected set; }
        public DateTime? StartReadingOnUtc { get; protected set; }
        public DateTime? FinisReadingOnUtc { get; protected set; }
        public UserBookStatus Status { get; protected set; }
        public string Note { get; protected set; }

        public UserBook( int bookId, int userId )
        {
            BookId = bookId;
            UserId = userId;
            StartReadingOnUtc = DateTime.UtcNow;
            Status = UserBookStatus.ReadyToRead;
        }

        protected UserBook()
        {
        }
    }
}