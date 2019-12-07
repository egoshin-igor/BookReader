using BookReader.Application.AppServices;
using BookReader.Application.Queries;
using BookReader.Application.Repositories;
using BookReader.Infrastructure.Queries;
using BookReader.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Lib.Repositories;
using MusicStore.Lib.Repositories.Abstractions;

namespace BookReader.Infrastructure.Foundation
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies( this IServiceCollection services )
        {
            // AppServices
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBookService, BookService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IUserBookRepository, UserBookRepository>();

            // Queries
            services.AddScoped<IGenreQuery, GenreQuery>();
            services.AddScoped<IBookQuery, BookQuery>();

            // Other
            services.AddScoped<IUnitOfWork, UnitOfWork<BookReaderDbContext>>();

            return services;
        }
    }
}
