using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookReader.Infrastructure.Foundation
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<BookReaderDbContext>
    {
        public BookReaderDbContext CreateDbContext( string[] args )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json", true )
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "BookReaderConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<BookReaderDbContext>();
            optionsBuilder.UseSqlServer( connectionString, x => x.MigrationsAssembly( "BookReader.Api" ) );

            return new BookReaderDbContext( optionsBuilder.Options );
        }
    }
}
