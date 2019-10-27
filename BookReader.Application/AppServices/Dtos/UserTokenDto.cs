namespace BookReader.Application.AppServices.Dtos
{
    public class UserTokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
