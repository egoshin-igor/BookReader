using BookReader.Application.AppServices;
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

            // Other
            services.AddScoped<IUnitOfWork, UnitOfWork<BookReaderDbContext>>();

            return services;
        }
    }
}
