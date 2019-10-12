using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Api.Dtos
{
    public class DetailBookDto
    {
        public int BookId { get; set; }
        public byte[] BookContent { get; set; }
        public int CurrentPage { get; set; }
    }
}
