using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Application.AppServices.Dtos;
using BookReader.Application.AppServices.Entities;

namespace BookReader.Application.AppServices
{
    public interface IBookService
    {
        Task AddBookAsync( AddBookDto addBookDto );
    }

    public class BookService : IBookService
    {
        private const string ImagesPath = @"D:\Studies\BookRWrapper\Images";
        private const string BookFilesPath = @"D:\Studies\BookRWrapper\BookFiles";

        public async Task AddBookAsync( AddBookDto addBookDto )
        {
            Directory.CreateDirectory( ImagesPath );
            Directory.CreateDirectory( BookFilesPath );
            var imageSaveResult = await SaveAsync( addBookDto.BookFile, BookFilesPath );
            var fileSaveResult = await SaveAsync( addBookDto.Image, ImagesPath );


        }

        private async Task<FileSaveResult> SaveAsync( FormFileAdapter formFile, string basePath )
        {
            string fileName = $"{Guid.NewGuid().ToString()}.{formFile.FileExtension}";
            var newFilePath = $@"{basePath}\{fileName}";
            using ( FileStream fs = File.Create( newFilePath ) )
            {
                await fs.WriteAsync( formFile.Data );
            }

            string folderName = basePath.Split( @"\" ).Last();
            return new FileSaveResult
            {
                RelativePath = $@"{folderName}/{fileName}"
            };
        }

        private class FileSaveResult
        {
            public string RelativePath { get; set; }
        }
    }
}
