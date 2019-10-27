using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Api.Dtos
{
    public class UpdateTokensRequest
    {
        public string RefreshToken { get; set; }
    }
}
