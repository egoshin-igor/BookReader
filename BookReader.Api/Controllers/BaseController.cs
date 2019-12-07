using System;
using BookReader.Application.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookReader.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public int UserId => GetUserId();

        private int GetUserId()
        {
            string userIdString = User.FindFirst( UserClaim.UserId )?.Value;
            if ( userIdString == null )
                throw new ApplicationException( "user id not found" );

            return int.Parse( userIdString );
        }
    }
}
