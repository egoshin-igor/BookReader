using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Application.AppServices.Dtos;
using BookReader.Application.AppServices.Entities;
using BookReader.Application.Repositories;
using BookReader.Core.Entities;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Application.AppServices
{
    public interface IBookService
    {
        Task AddBookAsync( AddBookDto addBookDto );
    }

    public class BookService : IBookService
    {
        private const string ImagesPath = @"D:\Studies\BookRWrapper\images";
        private const string BookFilesPath = @"D:\Studies\BookRWrapper\books";

        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserBookRepository _userBookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IUserBookRepository userBookRepository,
            IUnitOfWork unitOfWork )
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _userBookRepository = userBookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddBookAsync( AddBookDto addBookDto )
        {
            Directory.CreateDirectory( ImagesPath );
            Directory.CreateDirectory( BookFilesPath );
            var imageSaveResult = await SaveAsync( addBookDto.Image, ImagesPath );
            var fileSaveResult = await SaveAsync( addBookDto.BookFile, BookFilesPath );

            var author = new Author( addBookDto.Author );
            _authorRepository.Add( author );
            await _unitOfWork.CommitAsync();

            var book = new Book(
                addBookDto.Name,
                author.Id,
                addBookDto.GenreId,
                imageSaveResult.RelativePath,
                fileSaveResult.RelativePath
            );
            _bookRepository.Add( book );
            await _unitOfWork.CommitAsync();

            var userBook = new UserBook( book.Id, addBookDto.UserId );
            _userBookRepository.Add( userBook );
            await _unitOfWork.CommitAsync();
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
