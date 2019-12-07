using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookReader.Application.AppServices.Entities
{
    public class FormFileAdapter
    {
        public byte[] Data { get; private set; }
        public string FileName { get; private set; }
        public string FileExtension { get; private set; }

        public static async Task<FormFileAdapter> CreateAsync( IFormFile formFile )
        {
            byte[] fileBytes = await FileToBytes( formFile );

            return new FormFileAdapter
            {
                Data = fileBytes,
                FileName = formFile.FileName,
                FileExtension = formFile.FileName.Split( '.' ).Last()
            };
        }

        private static async Task<byte[]> FileToBytes( IFormFile formFile )
        {
            using ( var ms = new MemoryStream() )
            using ( Stream stream = formFile.OpenReadStream() )
            {
                await stream.CopyToAsync( ms );
                return ms.ToArray();
            }
        }
    }
}
